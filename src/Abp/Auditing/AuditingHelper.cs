using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.Timing;
using Castle.Core.Logging;

namespace Abp.Auditing
{
    /// <summary>
    /// ��ư�����
    /// </summary>
    public class AuditingHelper : IAuditingHelper, ITransientDependency
    {
        public ILogger Logger { get; set; }
        public IAbpSession AbpSession { get; set; }
        public IAuditingStore AuditingStore { get; set; }

        private readonly IAuditInfoProvider _auditInfoProvider;
        private readonly IAuditingConfiguration _configuration;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IAuditSerializer _auditSerializer;

        public AuditingHelper(
            IAuditInfoProvider auditInfoProvider, 
            IAuditingConfiguration configuration, 
            IUnitOfWorkManager unitOfWorkManager,
            IAuditSerializer auditSerializer)
        {
            _auditInfoProvider = auditInfoProvider;
            _configuration = configuration;
            _unitOfWorkManager = unitOfWorkManager;
            _auditSerializer = auditSerializer;

            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
            AuditingStore = SimpleLogAuditingStore.Instance;
        }

        /// <summary>
        /// �Ƿ�Ӧ�ñ��������־
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false)
        {
            // ���û��������ƹ��ܣ���ô������
            if (!_configuration.IsEnabled)
            {
                return false;
            }

            // ����û��������û�����δ����Ϊ�����û���¼�����־����ô������
            if (!_configuration.IsEnabledForAnonymousUsers && (AbpSession?.UserId == null))
            {
                return false;
            }

            if (methodInfo == null)
            {
                return false;
            }

            // ���ǹ�����������ô������
            if (!methodInfo.IsPublic)
            {
                return false;
            }

            // ���������AuditedAttribute�����ˣ���ô����
            if (methodInfo.IsDefined(typeof(AuditedAttribute), true))
            {
                return true;
            }

            // ���������DisableAuditingAttribute�����ˣ���ô������
            if (methodInfo.IsDefined(typeof(DisableAuditingAttribute), true))
            {
                return false;
            }

            var classType = methodInfo.DeclaringType;
            if (classType != null)
            {
                // �������AuditedAttribute����ô����
                if (classType.IsDefined(typeof(AuditedAttribute), true))
                {
                    return true;
                }

                // �������DisableAuditingAttribute�����ˣ���ô������
                if (classType.IsDefined(typeof(DisableAuditingAttribute), true))
                {
                    return false;
                }

                // ������������ļ���Selectors���棬��ô����
                if (_configuration.Selectors.Any(selector => selector.Predicate(classType)))
                {
                    return true;
                }
            }

            return defaultValue;
        }

        public AuditInfo CreateAuditInfo(MethodInfo method, object[] arguments)
        {
            return CreateAuditInfo(method, CreateArgumentsDictionary(method, arguments));
        }

        public AuditInfo CreateAuditInfo(MethodInfo method, IDictionary<string, object> arguments)
        {
            var auditInfo = new AuditInfo
            {
                TenantId = AbpSession.TenantId,
                UserId = AbpSession.UserId,
                ImpersonatorUserId = AbpSession.ImpersonatorUserId,
                ImpersonatorTenantId = AbpSession.ImpersonatorTenantId,
                ServiceName = method.DeclaringType != null
                    ? method.DeclaringType.FullName
                    : "",
                MethodName = method.Name,
                Parameters = ConvertArgumentsToJson(arguments),
                ExecutionTime = Clock.Now
            };

            try
            {
                _auditInfoProvider.Fill(auditInfo);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString(), ex);
            }

            return auditInfo;
        }

        public void Save(AuditInfo auditInfo)
        {
            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                AuditingStore.Save(auditInfo);
                uow.Complete();
            }
        }

        public async Task SaveAsync(AuditInfo auditInfo)
        {
            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                await AuditingStore.SaveAsync(auditInfo);
                await uow.CompleteAsync();
            }
        }

        private string ConvertArgumentsToJson(IDictionary<string, object> arguments)
        {
            try
            {
                if (arguments.IsNullOrEmpty())
                {
                    return "{}";
                }

                var dictionary = new Dictionary<string, object>();

                foreach (var argument in arguments)
                {
                    if (argument.Value != null && _configuration.IgnoredTypes.Any(t => t.IsInstanceOfType(argument.Value)))
                    {
                        dictionary[argument.Key] = null;
                    }
                    else
                    {
                        dictionary[argument.Key] = argument.Value;
                    }
                }

                return _auditSerializer.Serialize(dictionary);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString(), ex);
                return "{}";
            }
        }

        private static Dictionary<string, object> CreateArgumentsDictionary(MethodInfo method, object[] arguments)
        {
            var parameters = method.GetParameters();
            var dictionary = new Dictionary<string, object>();

            for (var i = 0; i < parameters.Length; i++)
            {
                dictionary[parameters[i].Name] = arguments[i];
            }

            return dictionary;
        }
    }
}
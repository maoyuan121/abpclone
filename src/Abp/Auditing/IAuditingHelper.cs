using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Abp.Auditing
{
    /// <summary>
    /// 审计帮助类
    /// </summary>
    public interface IAuditingHelper
    {
        /// <summary>
        /// 是否应该保存审计日志信息
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false);

        /// <summary>
        /// 创建审计日志
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        AuditInfo CreateAuditInfo(MethodInfo method, object[] arguments);
        AuditInfo CreateAuditInfo(MethodInfo method, IDictionary<string, object> arguments);

        /// <summary>
        /// 保存审计日志
        /// </summary>
        /// <param name="auditInfo"></param>
        void Save(AuditInfo auditInfo);
        Task SaveAsync(AuditInfo auditInfo);
    }
}
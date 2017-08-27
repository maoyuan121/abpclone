using System;
using System.Linq;
using Abp.Dependency;
using Castle.Core;

namespace Abp.Auditing
{
    /// <summary>
    /// 审计日志截断器的注册器
    /// </summary>
    internal static class AuditingInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            var auditingConfiguration = iocManager.Resolve<IAuditingConfiguration>();
            iocManager.IocContainer.Kernel.ComponentRegistered += (key, handler) =>
            {
                if (ShouldIntercept(auditingConfiguration, handler.ComponentModel.Implementation))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AuditingInterceptor)));
                }
            };
        }
        
        private static bool ShouldIntercept(IAuditingConfiguration auditingConfiguration, Type type)
        {
            // 如果这个类是auditingConfiguration.Selectors里面的类，那么应该截断记录审计日志
            if (auditingConfiguration.Selectors.Any(selector => selector.Predicate(type)))
            {
                return true;
            }

            // 如果这个类被AuditedAttribute修饰了，那么应该截断记录审计日志
            if (type.IsDefined(typeof(AuditedAttribute), true))
            {
                return true;
            }

            // 如果这个类有方法用AuditedAttribute修饰了得话，那么应该截断记录审计日志
            if (type.GetMethods().Any(m => m.IsDefined(typeof(AuditedAttribute), true)))
            {
                return true;
            }

            return false;
        }
    }
}
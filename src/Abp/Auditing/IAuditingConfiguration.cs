using System;
using System.Collections.Generic;

namespace Abp.Auditing
{
    /// <summary>
    /// 用来配置日志功能
    /// </summary>
    public interface IAuditingConfiguration
    {
        /// <summary>
        /// 启用/禁用审计日志功能
        /// 默认为true。如果设置为false，会完全禁用审计日志功能
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// 设为true的话，会为未登陆的用户启用审计日志功能
        /// Default: false.
        /// </summary>
        bool IsEnabledForAnonymousUsers { get; set; }

        /// <summary>
        /// 哪些类需要审计日志
        /// </summary>
        IAuditingSelectorList Selectors { get; }

        /// <summary>
        /// 哪些类不需要审计日志功能
        /// </summary>
        List<Type> IgnoredTypes { get; }
    }
}
using System;

namespace Abp.Configuration
{
    /// <summary>
    /// 定义配置的范围
    /// </summary>
    [Flags]
    public enum SettingScopes
    {
        /// <summary>
        /// 应用级别的配置
        /// </summary>
        Application = 1,

        /// <summary>
        /// 租户级别的配置
        /// </summary>
        Tenant = 2,

        /// <summary>
        /// 用户级别的配置
        /// </summary>
        User = 4
    }
}
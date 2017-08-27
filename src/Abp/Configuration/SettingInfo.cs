using System;

namespace Abp.Configuration
{
    /// <summary>
    /// 配置信息
    /// </summary>
    [Serializable]
    public class SettingInfo
    {
        /// <summary>
        /// 租户Id
        /// 如果为空，那么这个配置不是租户级别的
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 用户Id
        /// 如果为空，那么这个配置不是用户级别的
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 配置的唯一名.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 配置的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="SettingInfo"/> object.
        /// </summary>
        public SettingInfo()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="SettingInfo"/> object.
        /// </summary>
        /// <param name="tenantId">TenantId for this setting. TenantId is null if this setting is not Tenant level.</param>
        /// <param name="userId">UserId for this setting. UserId is null if this setting is not user level.</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        public SettingInfo(int? tenantId, long? userId, string name, string value)
        {
            TenantId = tenantId;
            UserId = userId;
            Name = name;
            Value = value;
        }
    }
}
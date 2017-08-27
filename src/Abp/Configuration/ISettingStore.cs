using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Configuration
{
    /// <summary>
    /// 这个接口用来从一个数据源(数据库)中来获取或者持续化配置
    /// </summary>
    public interface ISettingStore
    {
        /// <summary>
        /// Gets a setting or null.
        /// </summary>
        /// <param name="tenantId">TenantId or null</param>
        /// <param name="userId">UserId or null</param>
        /// <param name="name">Name of the setting</param>
        /// <returns>Setting object</returns>
        Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name);

        /// <summary>
        /// Deletes a setting.
        /// </summary>
        /// <param name="setting">Setting to be deleted</param>
        Task DeleteAsync(SettingInfo setting);

        /// <summary>
        /// Adds a setting.
        /// </summary>
        /// <param name="setting">Setting to add</param>
        Task CreateAsync(SettingInfo setting);

        /// <summary>
        /// Update a setting.
        /// </summary>
        /// <param name="setting">Setting to add</param>
        Task UpdateAsync(SettingInfo setting);

        /// <summary>
        /// Gets a list of setting.
        /// </summary>
        /// <param name="tenantId">TenantId or null</param>
        /// <param name="userId">UserId or null</param>
        /// <returns>List of settings</returns>
        Task<List<SettingInfo>> GetAllListAsync(int? tenantId, long? userId);
    }
}
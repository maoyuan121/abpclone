using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Configuration
{
    /// <summary>
    /// 加载，修改配置的接口
    /// </summary>
    public interface ISettingManager
    {
        /// <summary>
        /// 获取配置值
        /// It gets the setting value, overwritten by application, current tenant and current user if exists.
        /// </summary>
        /// <param name="name">配置的唯一名</param>
        /// <returns>Current value of the setting</returns>
        Task<string> GetSettingValueAsync(string name);

        /// <summary>
        /// 获取应用级别的配置值
        /// </summary>
        /// <param name="name">配置的唯一名</param>
        /// <returns>Current value of the setting for the application</returns>
        Task<string> GetSettingValueForApplicationAsync(string name);

        /// <summary>
        /// 获取租户级别的配置值
        /// It gets the setting value, overwritten by given tenant.
        /// </summary>
        /// <param name="name">配置的唯一名</param>
        /// <param name="tenantId">Tenant id</param>
        /// <returns>Current value of the setting</returns>
        Task<string> GetSettingValueForTenantAsync(string name, int tenantId);

        /// <summary>
        /// 获取用户级别的配置值
        /// It gets the setting value, overwritten by given tenant and user.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="tenantId">Tenant id</param>
        /// <param name="userId">User id</param>
        /// <returns>Current value of the setting for the user</returns>
        Task<string> GetSettingValueForUserAsync(string name, int? tenantId, long userId); //TODO: Can be overloaded for UserIdentifier.

        /// <summary>
        /// 获取所有的配置值
        /// It gets all setting values, overwritten by application, current tenant (if exists) and the current user (if exists).
        /// </summary>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync();

        /// <summary>
        /// 获取指定Scope的所有配置值
        /// It gets default values of all settings then overwrites by given scopes.
        /// </summary>
        /// <param name="scopes">One or more scope to overwrite</param>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(SettingScopes scopes);

        /// <summary>
        /// 获取应用级别所有的配置值
        /// It returns only settings those are explicitly set for the application.
        /// If a setting's default value is used, it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForApplicationAsync();

        /// <summary>
        /// 获取租户级别所有的配置值
        /// It returns only settings those are explicitly set for the tenant.
        /// If a setting's default value is used, it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <param name="tenantId">Tenant to get settings</param>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForTenantAsync(int tenantId);

        /// <summary>
        /// 获取用户级别所有的配置值
        /// It returns only settings those are explicitly set for the user.
        /// If a setting's value is not set for the user (for example if user uses the default value), it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <param name="user">User to get settings</param>
        /// <returns>All settings of the user</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForUserAsync(UserIdentifier user);

        /// <summary>
        /// 修改应用级别的配置值
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForApplicationAsync(string name, string value);

        /// <summary>
        /// 修改租户级别的配置值
        /// </summary>
        /// <param name="tenantId">TenantId</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForTenantAsync(int tenantId, string name, string value);

        /// <summary>
        /// 修改用户级别的配置值
        /// </summary>
        /// <param name="user">UserId</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForUserAsync(UserIdentifier user, string name, string value);
    }
}

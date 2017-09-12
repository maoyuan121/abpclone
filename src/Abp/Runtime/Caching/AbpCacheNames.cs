namespace Abp.Runtime.Caching
{
    /// <summary>
    /// ABP内置标准缓存名
    /// </summary>
    public static class AbpCacheNames
    {
        /// <summary>
        /// 应用配置缓存: AbpApplicationSettingsCache.
        /// </summary>
        public const string ApplicationSettings = "AbpApplicationSettingsCache";

        /// <summary>
        /// 租户配置缓存: AbpTenantSettingsCache.
        /// </summary>
        public const string TenantSettings = "AbpTenantSettingsCache";

        /// <summary>
        /// 用户配置缓存: AbpUserSettingsCache.
        /// </summary>
        public const string UserSettings = "AbpUserSettingsCache";

        /// <summary>
        /// Localization scripts cache: AbpLocalizationScripts.
        /// </summary>
        public const string LocalizationScripts = "AbpLocalizationScripts";
    }
}
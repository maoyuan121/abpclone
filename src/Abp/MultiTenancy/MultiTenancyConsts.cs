namespace Abp.MultiTenancy
{
    /// <summary>
    /// 多租户常量
    /// </summary>
    public static class MultiTenancyConsts
    {
        /// <summary>
        /// 默认租户ID：1
        /// </summary>
        public const int DefaultTenantId = 1;

        public const string TenantIdResolveKey = "Abp.TenantId";
    }
}
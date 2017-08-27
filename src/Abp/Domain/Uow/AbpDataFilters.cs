using Abp.Domain.Entities;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ABP中内置的数据过滤器
    /// </summary>
    public static class AbpDataFilters
    {
        /// <summary>
        /// 软删除过滤器
        /// 避免从数据库中将被逻辑删除的数据查出来
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";

        /// <summary>
        /// "MustHaveTenant".
        /// 避免将不属于当前租户的数据查出来
        /// </summary>
        public const string MustHaveTenant = "MustHaveTenant";

        /// <summary>
        /// "MayHaveTenant".
        /// 避免将不属于当前租户的数据查出来
        /// </summary>
        public const string MayHaveTenant = "MayHaveTenant";

        /// <summary>
        /// ABP中内置的数据过滤器的参数
        /// </summary>
        public static class Parameters
        {
            /// <summary>
            /// "tenantId".
            /// </summary>
            public const string TenantId = "tenantId";
        }
    }
}
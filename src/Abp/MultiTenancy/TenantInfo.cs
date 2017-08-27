namespace Abp.MultiTenancy
{
    /// <summary>
    /// 租户信息
    /// </summary>
    public class TenantInfo
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 租户名
        /// </summary>
        public string TenancyName { get; set; }

        public TenantInfo(int id, string tenancyName)
        {
            Id = id;
            TenancyName = tenancyName;
        }
    }
}
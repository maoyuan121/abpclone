namespace Abp.MultiTenancy
{
    /// <summary>
    /// ×â»§½âÎöÆ÷µÄCacheItem
    /// </summary>
    public class TenantResolverCacheItem
    {
        public int? TenantId { get; }

        public TenantResolverCacheItem(int? tenantId)
        {
            TenantId = tenantId;
        }
    }
}
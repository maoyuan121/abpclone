namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧��������CacheItem
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
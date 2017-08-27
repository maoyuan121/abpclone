namespace Abp.MultiTenancy
{
    /// <summary>
    /// 租户解析器Cache的空实现
    /// </summary>
    public class NullTenantResolverCache : ITenantResolverCache
    {
        public TenantResolverCacheItem Value
        {
            get { return null; }
            set {  }
        }
    }
}
namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧������Cache�Ŀ�ʵ��
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
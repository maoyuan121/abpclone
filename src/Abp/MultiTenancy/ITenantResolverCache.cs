using JetBrains.Annotations;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧��������Cache
    /// </summary>
    public interface ITenantResolverCache
    {
        [CanBeNull]
        TenantResolverCacheItem Value { get; set; }
    }
}
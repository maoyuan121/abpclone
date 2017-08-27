using JetBrains.Annotations;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// ×â»§½âÎöÆ÷µÄCache
    /// </summary>
    public interface ITenantResolverCache
    {
        [CanBeNull]
        TenantResolverCacheItem Value { get; set; }
    }
}
using JetBrains.Annotations;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// ×â»§´æ´¢
    /// </summary>
    public interface ITenantStore
    {
        [CanBeNull]
        TenantInfo Find(int tenantId);

        [CanBeNull]
        TenantInfo Find([NotNull] string tenancyName);
    }
}
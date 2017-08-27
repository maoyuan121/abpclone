using JetBrains.Annotations;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧�洢
    /// </summary>
    public interface ITenantStore
    {
        [CanBeNull]
        TenantInfo Find(int tenantId);

        [CanBeNull]
        TenantInfo Find([NotNull] string tenancyName);
    }
}
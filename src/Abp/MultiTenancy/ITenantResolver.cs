namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧������
    /// </summary>
    public interface ITenantResolver
    {
        int? ResolveTenantId();
    }
}
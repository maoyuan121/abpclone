namespace Abp.MultiTenancy
{
    /// <summary>
    /// 租户解析器的贡献者
    /// </summary>
    public interface ITenantResolveContributor
    {
        int? ResolveTenantId();
    }
}
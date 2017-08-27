namespace Abp.MultiTenancy
{
    /// <summary>
    /// ×â»§½âÎöÆ÷
    /// </summary>
    public interface ITenantResolver
    {
        int? ResolveTenantId();
    }
}
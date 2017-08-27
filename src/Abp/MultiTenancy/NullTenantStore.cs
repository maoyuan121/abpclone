namespace Abp.MultiTenancy
{
    /// <summary>
    /// 租户存储的空对象
    /// </summary>
    public class NullTenantStore : ITenantStore
    {
        public TenantInfo Find(int tenantId)
        {
            return null;
        }

        public TenantInfo Find(string tenancyName)
        {
            return null;
        }
    }
}
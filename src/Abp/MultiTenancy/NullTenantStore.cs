namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧�洢�Ŀն���
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
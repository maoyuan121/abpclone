namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧��Ϣ
    /// </summary>
    public class TenantInfo
    {
        /// <summary>
        /// �⻧ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �⻧��
        /// </summary>
        public string TenancyName { get; set; }

        public TenantInfo(int id, string tenancyName)
        {
            Id = id;
            TenancyName = tenancyName;
        }
    }
}
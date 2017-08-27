using Abp.Threading;

namespace Abp.Auditing
{
    /// <summary>
    /// 扩展<see cref="IAuditingStore"/>
    /// </summary>
    public static class AuditingStoreExtensions
    {
        /// <summary>
        /// 以同步的方式保存审计日志
        /// </summary>
        /// <param name="auditingStore">Auditing store</param>
        /// <param name="auditInfo">Audit informations</param>
        public static void Save(this IAuditingStore auditingStore, AuditInfo auditInfo)
        {
            AsyncHelper.RunSync(() => auditingStore.SaveAsync(auditInfo));
        }
    }
}
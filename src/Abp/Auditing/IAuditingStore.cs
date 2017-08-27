using System.Threading.Tasks;

namespace Abp.Auditing
{
    /// <summary>
    /// 用来存储审计日志
    /// 默认实现为<see cref="SimpleLogAuditingStore"/>.
    /// </summary>
    public interface IAuditingStore
    {
        /// <summary>
        /// 保存审计日志
        /// </summary>
        /// <param name="auditInfo">Audit informations</param>
        Task SaveAsync(AuditInfo auditInfo);
    }
}
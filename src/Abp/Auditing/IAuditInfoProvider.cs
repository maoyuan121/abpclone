namespace Abp.Auditing
{
    /// <summary>
    /// 提供一个接口在上层提供审计日志信息
    /// </summary>
    public interface IAuditInfoProvider
    {
        /// <summary>
        /// 填充审计日志信息的属性
        /// </summary>
        /// <param name="auditInfo">Audit info that is partially filled</param>
        void Fill(AuditInfo auditInfo);
    }
}
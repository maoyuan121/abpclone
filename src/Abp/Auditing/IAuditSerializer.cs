namespace Abp.Auditing
{
    /// <summary>
    /// 审计日志的序列化器
    /// </summary>
    public interface IAuditSerializer
    {
        string Serialize(object obj);
    }
}
namespace Abp.Auditing
{
    /// <summary>
    /// �����־�����л���
    /// </summary>
    public interface IAuditSerializer
    {
        string Serialize(object obj);
    }
}
namespace Abp.Logging
{
    /// <summary>
    /// ʵ�ָýӿڵ�����һ����־��������
    /// </summary>
    public interface IHasLogSeverity
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        LogSeverity Severity { get; set; }
    }
}
namespace Abp.Logging
{
    /// <summary>
    /// 实现该接口的类有一个日志级别属性
    /// </summary>
    public interface IHasLogSeverity
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        LogSeverity Severity { get; set; }
    }
}
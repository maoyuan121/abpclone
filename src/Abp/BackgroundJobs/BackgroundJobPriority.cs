namespace Abp.BackgroundJobs
{
    /// <summary>
    /// 后台工作的优先级别
    /// </summary>
    public enum BackgroundJobPriority : byte
    {
        /// <summary>
        /// Low.
        /// </summary>
        Low = 5,

        /// <summary>
        /// Below normal.
        /// </summary>
        BelowNormal = 10,

        /// <summary>
        /// Normal (default).
        /// </summary>
        Normal = 15,

        /// <summary>
        /// Above normal.
        /// </summary>
        AboveNormal = 20,

        /// <summary>
        /// High.
        /// </summary>
        High = 25
    }
}
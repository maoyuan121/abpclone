namespace Abp.Threading.BackgroundWorkers
{
    /// <summary>
    /// 用来管理后台工作
    /// </summary>
    public interface IBackgroundWorkerManager : IRunnable
    {
        /// <summary>
        /// 添加工作。如果<see cref="IBackgroundWorkerManager"/> 开始，那么立刻开始worker
        /// </summary>
        /// <param name="worker">
        /// The worker. It should be resolved from IOC.
        /// </param>
        void Add(IBackgroundWorker worker);
    }
}
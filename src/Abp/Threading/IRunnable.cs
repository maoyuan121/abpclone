namespace Abp.Threading
{
    /// <summary>
    /// 定义开始/停止线程服务的接口
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// 开始服务
        /// </summary>
        void Start();

        /// <summary>
        /// 停止服务Sends stop command to the service.
        /// Service may return immediately and stop asynchronously.
        /// A client should then call <see cref="WaitToStop"/> method to ensure it's stopped.
        /// </summary>
        void Stop();

        /// <summary>
        /// Waits the service to stop.
        /// </summary>
        void WaitToStop();
    }
}

using Abp.Configuration.Startup;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// 后台工作的配置
    /// </summary>
    public interface IBackgroundJobConfiguration
    {
        /// <summary>
        /// 启用还是禁用后台工作
        /// </summary>
        bool IsJobExecutionEnabled { get; set; }

        /// <summary>
        /// Gets the ABP configuration object.
        /// </summary>
        IAbpStartupConfiguration AbpConfiguration { get; }
    }
}
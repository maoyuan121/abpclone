namespace Abp.Auditing
{
    /// <summary>
    /// 客户端信息提供器
    /// </summary>
    public interface IClientInfoProvider
    {
        /// <summary>
        /// 浏览器信息
        /// </summary>
        string BrowserInfo { get; }

        /// <summary>
        /// 客户IP
        /// </summary>
        string ClientIpAddress { get; }

        /// <summary>
        /// 客户电脑
        /// </summary>
        string ComputerName { get; }
    }
}
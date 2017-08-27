namespace Abp.Auditing
{
    /// <summary>
    /// 客户端信息提供器的空实现对象
    /// </summary>
    public class NullClientInfoProvider : IClientInfoProvider
    {
        public static NullClientInfoProvider Instance { get; } = new NullClientInfoProvider();

        public string BrowserInfo => null;
        public string ClientIpAddress => null;
        public string ComputerName => null;
    }
}
using Abp.Dependency;
using Abp.Extensions;

namespace Abp.Auditing
{
    /// <summary>
    /// <see cref="IAuditInfoProvider" />的默认实现
    /// </summary>
    public class DefaultAuditInfoProvider : IAuditInfoProvider, ITransientDependency
    {
        /// <summary>
        /// 客户信息提供器
        /// </summary>
        public IClientInfoProvider ClientInfoProvider { get; set; }

        public DefaultAuditInfoProvider()
        {
            ClientInfoProvider = NullClientInfoProvider.Instance;
        }

        /// <summary>
        /// 使用客户信息提供器来填充审计日志里面那部分客户端信息
        /// </summary>
        /// <param name="auditInfo"></param>
        public virtual void Fill(AuditInfo auditInfo)
        {
            if (auditInfo.ClientIpAddress.IsNullOrEmpty())
            {
                auditInfo.ClientIpAddress = ClientInfoProvider.ClientIpAddress;
            }

            if (auditInfo.BrowserInfo.IsNullOrEmpty())
            {
                auditInfo.BrowserInfo = ClientInfoProvider.BrowserInfo;
            }

            if (auditInfo.ClientName.IsNullOrEmpty())
            {
                auditInfo.ClientName = ClientInfoProvider.ComputerName;
            }
        }
    }
}
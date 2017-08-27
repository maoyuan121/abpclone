using Abp.Application.Features;
using Abp.Dependency;

namespace Abp.Authorization
{
    /// <summary>
    /// 依赖权限的上下文
    /// </summary>
    public interface IPermissionDependencyContext
    {
        /// <summary>
        /// 要验证的用户
        /// </summary>
        UserIdentifier User { get; }

        /// <summary>
        /// Gets the <see cref="IIocResolver"/>.
        /// </summary>
        /// <value>
        /// The ioc resolver.
        /// </value>
        IIocResolver IocResolver { get; }

        /// <summary>
        /// Gets the <see cref="IFeatureChecker"/>.
        /// </summary>
        /// <value>
        /// 权限检查器The feature checker.
        /// </value>
        IPermissionChecker PermissionChecker { get; }
    }
}
using Abp.Threading;

namespace Abp.Authorization
{
    /// <summary>
    /// 依赖权限<see cref="IPermissionDependency"/>的扩展
    /// </summary>
    public static class PermissionDependencyExtensions
    {
        /// <summary>
        /// Checks if permission dependency is satisfied.
        /// </summary>
        /// <param name="permissionDependency">The permission dependency</param>
        /// <param name="context">Context.</param>
        public static bool IsSatisfied(this IPermissionDependency permissionDependency, IPermissionDependencyContext context)
        {
            return AsyncHelper.RunSync(() => permissionDependency.IsSatisfiedAsync(context));
        }
    }
}
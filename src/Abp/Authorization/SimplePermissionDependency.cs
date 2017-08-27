using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 依赖权限<see cref="IPermissionDependency"/>的简单实现
    /// 检查是否授予了权限
    /// </summary>
    public class SimplePermissionDependency : IPermissionDependency
    {
        /// <summary>
        /// 要检查的权限集合
        /// </summary>
        public string[] Permissions { get; set; }

        /// <summary>
        /// 是否需要满足Permissions里面的所有权限
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// 默认: false.
        /// </summary>
        public bool RequiresAll { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimplePermissionDependency"/> class.
        /// </summary>
        /// <param name="permissions">The features.</param>
        public SimplePermissionDependency(params string[] permissions)
        {
            Permissions = permissions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimplePermissionDependency"/> class.
        /// </summary>
        /// <param name="requiresAll">
        /// If this is set to true, all of the <see cref="Permissions"/> must be granted.
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// </param>
        /// <param name="features">The features.</param>
        public SimplePermissionDependency(bool requiresAll, params string[] features)
            : this(features)
        {
            RequiresAll = requiresAll;
        }

        /// 是否满足
        public Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context)
        {
            return context.User != null
                ? context.PermissionChecker.IsGrantedAsync(context.User, RequiresAll, Permissions)
                : context.PermissionChecker.IsGrantedAsync(RequiresAll, Permissions);
        }
    }
}
using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 依赖权限
    /// </summary>
    public interface IPermissionDependency
    {
        /// <summary>
        /// 检查是否满足依赖权限
        /// </summary>
        /// <param name="context">Context.</param>
        Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context);
    }
}
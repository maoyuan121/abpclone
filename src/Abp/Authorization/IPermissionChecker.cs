using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 检查用户权限
    /// </summary>
    public interface IPermissionChecker
    {
        /// <summary>
        /// 检查用户是否被授予了一个权限
        /// </summary>
        /// <param name="permissionName">Name of the permission</param>
        Task<bool> IsGrantedAsync(string permissionName);

        /// <summary>
        /// 检查指定用户是否被授予了一个权限
        /// </summary>
        /// <param name="user">User to check</param>
        /// <param name="permissionName">Name of the permission</param>
        Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName);
    }
}
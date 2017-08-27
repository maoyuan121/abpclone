using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// ����û�Ȩ��
    /// </summary>
    public interface IPermissionChecker
    {
        /// <summary>
        /// ����û��Ƿ�������һ��Ȩ��
        /// </summary>
        /// <param name="permissionName">Name of the permission</param>
        Task<bool> IsGrantedAsync(string permissionName);

        /// <summary>
        /// ���ָ���û��Ƿ�������һ��Ȩ��
        /// </summary>
        /// <param name="user">User to check</param>
        /// <param name="permissionName">Name of the permission</param>
        Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName);
    }
}
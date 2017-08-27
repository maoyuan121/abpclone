using System.Collections.Generic;
using Abp.MultiTenancy;

namespace Abp.Authorization
{
    /// <summary>
    /// 权限管理器
    /// </summary>
    public interface IPermissionManager
    {
        /// <summary>
        /// 根据<paramref name="name"/>获取权限，如果没找到就抛出异常
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        Permission GetPermission(string name);

        /// <summary>
        /// 根据<paramref name="name"/>获取权限，如果没找到就返回NULL
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        Permission GetPermissionOrNull(string name);

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <param name="tenancyFilter">用来标识是否启用/禁用tenancy数据过滤器</param>
        IReadOnlyList<Permission> GetAllPermissions(bool tenancyFilter = true);

        /// <summary>
        /// 获取所有权限（租户的，Host的，或者租户和Host的）
        /// </summary>
        /// <param name="multiTenancySides">Multi-tenancy side to filter</param>
        IReadOnlyList<Permission> GetAllPermissions(MultiTenancySides multiTenancySides);
    }
}

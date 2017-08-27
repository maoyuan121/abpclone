using System;
using Abp.Application.Services;

namespace Abp.Authorization
{
    /// <summary>
    /// 用在应用服务的方法上 (所谓应用服务就是实现了<see cref="IApplicationService"/>的类)
    /// 确保方法是被有权限的用户访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AbpAuthorizeAttribute : Attribute, IAbpAuthorizeAttribute
    {
        /// <summary>
        /// 验证权限的权限名集合
        /// </summary>
        public string[] Permissions { get; }

        /// <summary>
        /// 如果设置为true的话，那么必须有里面所有的权限才能访问
        /// 如果设置为false的话，那么有<see cref="Permissions"/>其中的一个权限就能访问
        /// 默认值: false.
        /// </summary>
        public bool RequireAllPermissions { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="AbpAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="permissions">A list of permissions to authorize</param>
        public AbpAuthorizeAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }
    }
}

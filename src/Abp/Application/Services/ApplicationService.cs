using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Features;
using Abp.Authorization;
using Abp.Runtime.Session;

namespace Abp.Application.Services
{
    /// <summary>
    /// 应用服务的抽象基类
    /// </summary>
    public abstract class ApplicationService : AbpServiceBase, IApplicationService, IAvoidDuplicateCrossCuttingConcerns
    {
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };

        /// <summary>
        /// 获取当前的session信息
        /// </summary>
        public IAbpSession AbpSession { get; set; }
        
        /// <summary>
        /// 权限管理器
        /// </summary>
        public IPermissionManager PermissionManager { protected get; set; }

        /// <summary>
        /// 权限检查器
        /// </summary>
        public IPermissionChecker PermissionChecker { protected get; set; }

        /// <summary>
        /// feature管理器
        /// </summary>
        public IFeatureManager FeatureManager { protected get; set; }

        /// <summary>
        /// feature检查器
        /// </summary>
        public IFeatureChecker FeatureChecker { protected get; set; }

        /// <summary>
        /// 获取aop
        /// </summary>
        public List<string> AppliedCrossCuttingConcerns { get; } = new List<string>();

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ApplicationService()
        {
            AbpSession = NullAbpSession.Instance;
            PermissionChecker = NullPermissionChecker.Instance;
        }

        /// <summary>
        /// 检查当前用户是有授予了某个权限 - 异步
        /// </summary>
        /// <param name="permissionName">权限名</param>
        protected virtual Task<bool> IsGrantedAsync(string permissionName)
        {
            return PermissionChecker.IsGrantedAsync(permissionName);
        }

        /// <summary>
        /// 检查当前用户是有授予了某个权限 - 同步
        /// </summary>
        /// <param name="permissionName">权限名</param>
        protected virtual bool IsGranted(string permissionName)
        {
            return PermissionChecker.IsGranted(permissionName);
        }

        /// <summary>
        /// 检查当前租户是否授予了某个feature - 异步
        /// </summary>
        /// <param name="featureName">feature名</param>
        /// <returns></returns>
        protected virtual Task<bool> IsEnabledAsync(string featureName)
        {
            return FeatureChecker.IsEnabledAsync(featureName);
        }

        /// <summary>
        /// 检查当前租户是否授予了某个feature - 同步
        /// </summary>
        /// <param name="featureName">feature名</param>
        /// <returns></returns>
        protected virtual bool IsEnabled(string featureName)
        {
            return FeatureChecker.IsEnabled(featureName);
        }
    }
}

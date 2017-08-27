using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Abp.Localization;
using Abp.Threading;

namespace Abp.Authorization
{
    /// <summary>
    /// 权限检查器的扩展方法
    /// </summary>
    public static class PermissionCheckerExtensions
    {
        /// <summary>
        /// 检查当前用户是否有某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionName">Name of the permission</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, string permissionName)
        {
            return AsyncHelper.RunSync(() => permissionChecker.IsGrantedAsync(permissionName));
        }

        /// <summary>
        /// 检查指定用户是否有某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="user">User to check</param>
        /// <param name="permissionName">Name of the permission</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, UserIdentifier user, string permissionName)
        {
            return AsyncHelper.RunSync(() => permissionChecker.IsGrantedAsync(user, permissionName));
        }

        /// <summary>
        /// 检查指定用户是否有权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="user">被检查的用户</param>
        /// <param name="requiresAll">设为True，表示需要有所有的权限。False，表示只要有其中一个权限即可</param>
        /// <param name="permissionNames">Name of the permissions</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, UserIdentifier user, bool requiresAll, params string[] permissionNames)
        {
            return AsyncHelper.RunSync(() => IsGrantedAsync(permissionChecker, user, requiresAll, permissionNames));
        }

        /// <summary>
        /// 检查指定用户是否有权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="user">被检查的用户</param>
        /// <param name="requiresAll">设为True，表示需要有所有的权限。False，表示只要有其中一个权限即可</param>
        /// <param name="permissionNames">Name of the permissions</param>
        public static async Task<bool> IsGrantedAsync(this IPermissionChecker permissionChecker, UserIdentifier user, bool requiresAll, params string[] permissionNames)
        {
            if (permissionNames.IsNullOrEmpty())
            {
                return true;
            }

            if (requiresAll)
            {
                foreach (var permissionName in permissionNames)
                {
                    if (!(await permissionChecker.IsGrantedAsync(user, permissionName)))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                foreach (var permissionName in permissionNames)
                {
                    if (await permissionChecker.IsGrantedAsync(user, permissionName))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 检查当前用户是否有权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requiresAll">True, to require all given permissions are granted. False, to require one or more.</param>
        /// <param name="permissionNames">Name of the permissions</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, bool requiresAll, params string[] permissionNames)
        {
            return AsyncHelper.RunSync(() => IsGrantedAsync(permissionChecker, requiresAll, permissionNames));
        }

        /// <summary>
        /// Checks if current user is granted for given permission.
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requiresAll">True, to require all given permissions are granted. False, to require one or more.</param>
        /// <param name="permissionNames">Name of the permissions</param>
        public static async Task<bool> IsGrantedAsync(this IPermissionChecker permissionChecker, bool requiresAll, params string[] permissionNames)
        {
            if (permissionNames.IsNullOrEmpty())
            {
                return true;
            }

            if (requiresAll)
            {
                foreach (var permissionName in permissionNames)
                {
                    if (!(await permissionChecker.IsGrantedAsync(permissionName)))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                foreach (var permissionName in permissionNames)
                {
                    if (await permissionChecker.IsGrantedAsync(permissionName))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 验证当前用户是否有权限
        /// 如果没有权限就抛出 <see cref="AbpAuthorizationException"/>异常
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionNames">Name of the permissions to authorize</param>
        /// <exception cref="AbpAuthorizationException">Throws authorization exception if</exception>
        public static void Authorize(this IPermissionChecker permissionChecker, params string[] permissionNames)
        {
            Authorize(permissionChecker, false, permissionNames);
        }

        /// <summary>
        /// 验证当前用户是否有权限
        /// 如果没有权限就抛出 <see cref="AbpAuthorizationException"/>异常
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requireAll">
        /// If this is set to true, all of the <see cref="permissionNames"/> must be granted.
        /// If it's false, at least one of the <see cref="permissionNames"/> must be granted.
        /// </param>
        /// <param name="permissionNames">Name of the permissions to authorize</param>
        /// <exception cref="AbpAuthorizationException">Throws authorization exception if</exception>
        public static void Authorize(this IPermissionChecker permissionChecker, bool requireAll, params string[] permissionNames)
        {
            AsyncHelper.RunSync(() => AuthorizeAsync(permissionChecker, requireAll, permissionNames));
        }

        /// <summary>
        /// 验证当前用户是否有权限
        /// 如果没有权限就抛出 <see cref="AbpAuthorizationException"/>异常
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionNames">Name of the permissions to authorize</param>
        /// <exception cref="AbpAuthorizationException">Throws authorization exception if</exception>
        public static Task AuthorizeAsync(this IPermissionChecker permissionChecker, params string[] permissionNames)
        {
            return AuthorizeAsync(permissionChecker, false, permissionNames);
        }

        /// <summary>
        /// 验证当前用户是否有权限
        /// 如果没有权限就抛出 <see cref="AbpAuthorizationException"/>异常
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requireAll">
        /// If this is set to true, all of the <see cref="permissionNames"/> must be granted.
        /// If it's false, at least one of the <see cref="permissionNames"/> must be granted.
        /// </param>
        /// <param name="permissionNames">Name of the permissions to authorize</param>
        /// <exception cref="AbpAuthorizationException">Throws authorization exception if</exception>
        public static async Task AuthorizeAsync(this IPermissionChecker permissionChecker, bool requireAll, params string[] permissionNames)
        {
            if (await IsGrantedAsync(permissionChecker, requireAll, permissionNames))
            {
                return;
            }

            var localizedPermissionNames = LocalizePermissionNames(permissionChecker, permissionNames);

            if (requireAll)
            {
                throw new AbpAuthorizationException(
                    string.Format(
                        L(
                            permissionChecker,
                            "AllOfThesePermissionsMustBeGranted",
                            "Required permissions are not granted. All of these permissions must be granted: {0}"
                        ),
                        string.Join(", ", localizedPermissionNames)
                    )
                );
            }
            else
            {
                throw new AbpAuthorizationException(
                    string.Format(
                        L(
                            permissionChecker,
                            "AtLeastOneOfThesePermissionsMustBeGranted",
                            "Required permissions are not granted. At least one of these permissions must be granted: {0}"
                        ),
                        string.Join(", ", localizedPermissionNames)
                    )
                );
            }
        }

        public static string L(IPermissionChecker permissionChecker, string name, string defaultValue)
        {
            if (!(permissionChecker is IIocManagerAccessor))
            {
                return defaultValue;
            }

            var iocManager = (permissionChecker as IIocManagerAccessor).IocManager;
            using (var localizationManager = iocManager.ResolveAsDisposable<ILocalizationManager>())
            {
                return localizationManager.Object.GetString(AbpConsts.LocalizationSourceName, name);
            }
        }

        public static string[] LocalizePermissionNames(IPermissionChecker permissionChecker, string[] permissionNames)
        {
            if (!(permissionChecker is IIocManagerAccessor))
            {
                return permissionNames;
            }

            var iocManager = (permissionChecker as IIocManagerAccessor).IocManager;
            using (var localizationContext = iocManager.ResolveAsDisposable<ILocalizationContext>())
            {
                using (var permissionManager = iocManager.ResolveAsDisposable<IPermissionManager>())
                {
                    return permissionNames.Select(permissionName =>
                    {
                        var permission = permissionManager.Object.GetPermissionOrNull(permissionName);
                        return permission == null
                            ? permissionName
                            : permission.DisplayName.Localize(localizationContext.Object);
                    }).ToArray();
                }
            }
        }
    }
}
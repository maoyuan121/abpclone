using Abp.Dependency;

namespace Abp.Authorization
{
    /// <summary>
    /// 这个接口用来定义一个应用的权限
    /// 实现它来为你的module定义权限
    /// </summary>
    public abstract class AuthorizationProvider : ITransientDependency
    {
        /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public abstract void SetPermissions(IPermissionDefinitionContext context);
    }
}
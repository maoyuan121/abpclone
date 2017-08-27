using Abp.Dependency;

namespace Abp.Authorization
{
    /// <summary>
    /// ����ӿ���������һ��Ӧ�õ�Ȩ��
    /// ʵ������Ϊ���module����Ȩ��
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
using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// ����Ȩ��<see cref="IPermissionDependency"/>�ļ�ʵ��
    /// ����Ƿ�������Ȩ��
    /// </summary>
    public class SimplePermissionDependency : IPermissionDependency
    {
        /// <summary>
        /// Ҫ����Ȩ�޼���
        /// </summary>
        public string[] Permissions { get; set; }

        /// <summary>
        /// �Ƿ���Ҫ����Permissions���������Ȩ��
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// Ĭ��: false.
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

        /// �Ƿ�����
        public Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context)
        {
            return context.User != null
                ? context.PermissionChecker.IsGrantedAsync(context.User, RequiresAll, Permissions)
                : context.PermissionChecker.IsGrantedAsync(RequiresAll, Permissions);
        }
    }
}
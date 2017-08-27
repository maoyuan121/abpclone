using Abp.Domain.Entities;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ABP�����õ����ݹ�����
    /// </summary>
    public static class AbpDataFilters
    {
        /// <summary>
        /// ��ɾ��������
        /// ��������ݿ��н����߼�ɾ�������ݲ����
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";

        /// <summary>
        /// "MustHaveTenant".
        /// ���⽫�����ڵ�ǰ�⻧�����ݲ����
        /// </summary>
        public const string MustHaveTenant = "MustHaveTenant";

        /// <summary>
        /// "MayHaveTenant".
        /// ���⽫�����ڵ�ǰ�⻧�����ݲ����
        /// </summary>
        public const string MayHaveTenant = "MayHaveTenant";

        /// <summary>
        /// ABP�����õ����ݹ������Ĳ���
        /// </summary>
        public static class Parameters
        {
            /// <summary>
            /// "tenantId".
            /// </summary>
            public const string TenantId = "tenantId";
        }
    }
}
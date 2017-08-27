using System;
using System.Reflection;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// uow�İ�����
    /// ��Ҫ�����ж�һ������߷����Ƿ�Ӧ�����ù�����Ԫ
    /// </summary>
    internal static class UnitOfWorkHelper
    {
        /// <summary>
        /// �Ƿ���Ĭ��Լ���������ʹ��uow��
        /// ��IRepository, IApplicationService��ʵ����
        /// </summary>
        /// <param name="type">Type to check</param>
        public static bool IsConventionalUowClass(Type type)
        {
            return typeof(IRepository).IsAssignableFrom(type) || typeof(IApplicationService).IsAssignableFrom(type);
        }

        /// <summary>
        /// Returns true if given method has UnitOfWorkAttribute attribute.
        /// </summary>
        /// <param name="methodInfo">Method info to check</param>
        public static bool HasUnitOfWorkAttribute(MemberInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }

        /// <summary>
        /// Returns UnitOfWorkAttribute it exists.
        /// </summary>
        /// <param name="methodInfo">Method info to check</param>
        public static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof (UnitOfWorkAttribute), false);
            if (attrs.Length <= 0)
            {
                return null;
            }

            return (UnitOfWorkAttribute) attrs[0];
        }
    }
}
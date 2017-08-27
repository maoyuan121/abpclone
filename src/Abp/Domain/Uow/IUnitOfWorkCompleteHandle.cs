using System;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// �������һ��������Ԫ
    /// ����ӿڲ���ֱ��ע��/ʹ��
    /// Ӧ��ʹ��<see cref="IUnitOfWorkManager"/>
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// ���һ��������Ԫ
        /// </summary>
        void Complete();

        /// <summary>
        /// �첽�����һ��������Ԫ
        /// </summary>
        Task CompleteAsync();
    }
}
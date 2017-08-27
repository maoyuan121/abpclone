using System;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ����ӿ�����ABP�ڲ�ʹ���ˣ���Ҫֱ��������ӿ�
    /// ʹ��<see cref="IUnitOfWorkManager.Begin()"/>��ʼһ��������Ԫ
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// Unique id of this UOW.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Reference to the outer UOW if exists.
        /// </summary>
        IUnitOfWork Outer { get; set; }
        
        /// <summary>
        /// ʹ�ø�����option��ʼһ��������Ԫ
        /// </summary>
        /// <param name="options">Unit of work options</param>
        void Begin(UnitOfWorkOptions options);
    }
}
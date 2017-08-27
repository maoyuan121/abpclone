using System;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 这个接口是在ABP内部使用了，不要直接用这个接口
    /// 使用<see cref="IUnitOfWorkManager.Begin()"/>开始一个工作单元
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
        /// 使用给定的option开始一个工作单元
        /// </summary>
        /// <param name="options">Unit of work options</param>
        void Begin(UnitOfWorkOptions options);
    }
}
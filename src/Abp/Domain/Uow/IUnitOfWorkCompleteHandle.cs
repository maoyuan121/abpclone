using System;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 用来完成一个工作单元
    /// 这个接口不能直接注入/使用
    /// 应该使用<see cref="IUnitOfWorkManager"/>
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// 完成一个工作单元
        /// </summary>
        void Complete();

        /// <summary>
        /// 异步的完成一个工作单元
        /// </summary>
        Task CompleteAsync();
    }
}
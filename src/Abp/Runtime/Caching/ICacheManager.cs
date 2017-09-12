using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// <see cref="ICache"/>对象的一个上层容器
    /// 应该是单例模式，用来跟踪/管理<see cref="ICache"/>对象
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 获取所有的cache
        /// </summary>
        IReadOnlyList<ICache> GetAllCaches();

        /// <summary>
        /// 获取一个<see cref="ICache"/>实例
        /// 如果不存在的话会创建一个缓存
        /// </summary>
        /// <param name="name">
        /// 缓存的唯一名
        /// </param>
        [NotNull] ICache GetCache([NotNull] string name);
    }
}

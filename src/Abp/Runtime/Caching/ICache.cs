using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// 定义一个缓存用来存储或者通过key获取缓存项
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// 缓存的唯一名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认的缓存过期时间
        /// 默认值: 60分钟
        /// 可以用configuration修改
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// 缓存的绝对过期时间
        /// 默认值：null
        /// </summary>
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        /// <summary>
        /// 获取一个缓存项（cache item）
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="factory">如果没用缓存用来创建缓存的工厂方法</param>
        /// <returns>缓存项</returns>
        object Get(string key, Func<string, object> factory);

        /// <summary>
        /// 获取一个缓存项（cache item）
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="factory">如果没用缓存用来创建缓存的工厂方法</param>
        /// <returns>缓存项</returns>
        Task<object> GetAsync(string key, Func<string, Task<object>> factory);

        /// <summary>
        /// 获取一个缓存项，如果没有的话返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>缓存项或者null</returns>
        object GetOrDefault(string key);

        /// <summary>
        /// 获取一个缓存项，如果没有的话返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>缓存项或者null</returns>
        Task<object> GetOrDefaultAsync(string key);

        /// <summary>
        /// 设置一个缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="slidingExpireTime">过期时间</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// 设置一个缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="slidingExpireTime">过期时间</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// 清除一个缓存项
        /// </summary>
        /// <param name="key">键</param>
        void Remove(string key);

        /// <summary>
        /// 清除一个缓存项
        /// </summary>
        /// <param name="key">键</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// 清空这个缓存的所有item
        /// </summary>
        void Clear();

        /// <summary>
        /// 清空这个缓存的所有item
        /// </summary>
        Task ClearAsync();
    }
}
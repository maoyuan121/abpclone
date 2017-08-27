using System;

namespace Abp.Timing
{
    /// <summary>
    /// 定义一些通用的关于日期操作的接口
    /// </summary>
    public interface IClockProvider
    {
        /// <summary>
        /// 获取当前日期
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 获取DateTimeKind
        /// </summary>
        DateTimeKind Kind { get; }

        /// <summary>
        /// 是否支持多时区
        /// </summary>
        bool SupportsMultipleTimezone { get; }

        /// <summary>
        /// 转换日期 <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">DateTime to be normalized.</param>
        /// <returns>Normalized DateTime</returns>
        DateTime Normalize(DateTime dateTime);
    }
}
using System;

namespace Abp.Timing
{
    /// <summary>
    /// 实现<see cref="IClockProvider"/>使用UTC时间
    /// 支持多时区
    /// </summary>
    public class UtcClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.UtcNow;

        public DateTimeKind Kind => DateTimeKind.Utc;

        public bool SupportsMultipleTimezone => true;

        /// <summary>
        /// 如果日期Kind是Local那么把日期转换为UTC时间
        /// 如果日期Kind是UnSpecified那么返回日期，并设置日期的Kind是UTC
        /// 如果日期Kind是Utc那么直接返回
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return dateTime;
        }

        internal UtcClockProvider()
        {

        }
    }
}
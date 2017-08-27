using System;

namespace Abp.Timing
{
    /// <summary>
    /// 实现<see cref="IClockProvider"/>使用本地时间
    /// 不支持多时区
    /// </summary>
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTimeKind Kind => DateTimeKind.Local;

        public bool SupportsMultipleTimezone => false;

        /// <summary>
        /// 如果日期Kind是Unspecified那么指定日期Kind为Local并返回
        /// 如果日期Kind是Utc那么将日期转换为Utc日期
        /// 如果日期Kind是Local那么直接日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            }

            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime.ToLocalTime();
            }

            return dateTime;
        }

        internal LocalClockProvider()
        {

        }
    }
}
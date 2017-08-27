using System;

namespace Abp.Timing
{
    /// <summary>
    /// 实现<see cref="IClockProvider"/>使用Unspecified时间
    /// 不支持多时区
    /// </summary>
    public class UnspecifiedClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTimeKind Kind => DateTimeKind.Unspecified;

        public bool SupportsMultipleTimezone => false;

        public DateTime Normalize(DateTime dateTime)
        {
            return dateTime;
        }

        internal UnspecifiedClockProvider()
        {
            
        }
    }
}
using System;

namespace Abp.Timing
{
    /// <summary>
    /// ʵ��<see cref="IClockProvider"/>ʹ��UTCʱ��
    /// ֧�ֶ�ʱ��
    /// </summary>
    public class UtcClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.UtcNow;

        public DateTimeKind Kind => DateTimeKind.Utc;

        public bool SupportsMultipleTimezone => true;

        /// <summary>
        /// �������Kind��Local��ô������ת��ΪUTCʱ��
        /// �������Kind��UnSpecified��ô�������ڣ����������ڵ�Kind��UTC
        /// �������Kind��Utc��ôֱ�ӷ���
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
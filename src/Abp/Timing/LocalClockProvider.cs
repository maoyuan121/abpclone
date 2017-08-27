using System;

namespace Abp.Timing
{
    /// <summary>
    /// ʵ��<see cref="IClockProvider"/>ʹ�ñ���ʱ��
    /// ��֧�ֶ�ʱ��
    /// </summary>
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTimeKind Kind => DateTimeKind.Local;

        public bool SupportsMultipleTimezone => false;

        /// <summary>
        /// �������Kind��Unspecified��ôָ������KindΪLocal������
        /// �������Kind��Utc��ô������ת��ΪUtc����
        /// �������Kind��Local��ôֱ������
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
using System;

namespace Abp.Timing.Timezone
{
    /// <summary>
    /// 时区转换接口
    /// </summary>
    public interface ITimeZoneConverter
    {
        /// <summary>
        /// 接受一个时间，将其转换为用户时区的时间
        /// If timezone setting is not specified, returns given date.
        /// </summary>
        /// <param name="date">Base date to convert</param>
        /// <param name="tenantId">TenantId of user</param>
        /// <param name="userId">UserId to convert date for</param>
        /// <returns></returns>
        DateTime? Convert(DateTime? date, int? tenantId, long userId);

        /// <summary>
        /// 接受一个时间，将其转换为租户时区的时间
        /// If timezone setting is not specified, returns given date.
        /// </summary>
        /// <param name="date">Base date to convert</param>
        /// <param name="tenantId">TenantId  to convert date for</param>
        /// <returns></returns>
        DateTime? Convert(DateTime? date, int tenantId);

        /// <summary>
        /// 接受一个时间，将其转换为应用时区的时间
        /// If timezone setting is not specified, returns given date.
        /// </summary>
        /// <param name="date">Base date to convert</param>
        /// <returns></returns>
        DateTime? Convert(DateTime? date);
    }
}

namespace Abp
{
    /// <summary>
    /// 用户标识接口
    /// </summary>
    public interface IUserIdentifier
    {
        /// <summary>
        /// 租户ID。如果是host用户 tenantid为空
        /// </summary>
        int? TenantId { get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        long UserId { get; }
    }
}
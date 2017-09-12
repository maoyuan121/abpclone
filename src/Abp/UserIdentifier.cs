using System;
using Abp.Extensions;

namespace Abp
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [Serializable]
    public class UserIdentifier : IUserIdentifier
    {
        /// <summary>
        /// 用户的租户ID
        /// 如果是host用户 tenantid为空
        /// </summary>
        public int? TenantId { get; protected set; }

        /// <summary>
        /// 用户的ID
        /// </summary>
        public long UserId { get; protected set; }
        
        protected UserIdentifier()
        {

        }

        public UserIdentifier(int? tenantId, long userId)
        {
            TenantId = tenantId;
            UserId = userId;
        }

        /// <summary>
        /// 解析字符串，创建一个<see cref="UserIdentifier"/>实例
        /// </summary>
        /// <param name="userIdentifierString">
        /// 应该是下面的格式
        /// 
        /// - "userId@tenantId". Ex: "42@3" (for tenant users).
        /// - "userId". Ex: 1 (for host users)
        /// </param>
        public static UserIdentifier Parse(string userIdentifierString)
        {
            if (userIdentifierString.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(userIdentifierString), "userAtTenant can not be null or empty!");
            }

            var splitted = userIdentifierString.Split('@');
            if (splitted.Length == 1)
            {
                return new UserIdentifier(null, splitted[0].To<long>());

            }

            if (splitted.Length == 2)
            {
                return new UserIdentifier(splitted[1].To<int>(), splitted[0].To<long>());
            }

            throw new ArgumentException("userAtTenant is not properly formatted", nameof(userIdentifierString));
        }

        /// <summary>
        /// 返回一个字符串代表<see cref="UserIdentifier"/>实例
        /// 应该是下面的格式
        /// 
        /// - "userId@tenantId". Ex: "42@3" (for tenant users).
        /// - "userId". Ex: 1 (for host users)
        /// </summary>
        public string ToUserIdentifierString()
        {
            if (TenantId == null)
            {
                return UserId.ToString();
            }

            return UserId + "@" + TenantId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is UserIdentifier))
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            //Transient objects are not considered as equal
            var other = (UserIdentifier)obj;

            //Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return TenantId == other.TenantId && UserId == other.UserId;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return TenantId == null ? (int)UserId : (int)(TenantId.Value ^ UserId);
        }

        /// <inheritdoc/>
        public static bool operator ==(UserIdentifier left, UserIdentifier right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(UserIdentifier left, UserIdentifier right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return ToUserIdentifierString();
        }
    }
}

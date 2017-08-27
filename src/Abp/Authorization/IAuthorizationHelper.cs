using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 定义权限帮助类
    /// </summary>
    public interface IAuthorizationHelper
    {
        Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(MethodInfo methodInfo);
    }
}
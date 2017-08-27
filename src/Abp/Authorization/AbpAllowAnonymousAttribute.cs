using System;

namespace Abp.Authorization
{
    /// <summary>
    /// 让一个方法能被匿名用户访问
    /// Suppress <see cref="AbpAuthorizeAttribute"/> defined in the class containing that method.
    /// </summary>
    public class AbpAllowAnonymousAttribute : Attribute, IAbpAllowAnonymousAttribute
    {

    }
}
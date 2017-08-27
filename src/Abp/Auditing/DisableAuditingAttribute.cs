using System;

namespace Abp.Auditing
{
    /// <summary>
    /// 对一个类、方法、属性禁用审计日志
    /// all methods of a class or interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisableAuditingAttribute : Attribute
    {

    }
}
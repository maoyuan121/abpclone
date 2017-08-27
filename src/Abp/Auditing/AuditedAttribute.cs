using System;

namespace Abp.Auditing
{
    /// <summary>
    /// 标识一个方法或者一个类需要添加审计日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuditedAttribute : Attribute
    {

    }
}

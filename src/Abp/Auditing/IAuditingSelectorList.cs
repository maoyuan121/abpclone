using System.Collections.Generic;

namespace Abp.Auditing
{
    /// <summary>
    /// 审计日志选择器列表
    /// </summary>
    public interface IAuditingSelectorList : IList<NamedTypeSelector>
    {
        /// <summary>
        /// Removes a selector by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool RemoveByName(string name);
    }
}
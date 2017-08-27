using System.Collections.Generic;

namespace Abp.Auditing
{
    /// <summary>
    /// 审计日志选择器列表
    /// </summary>
    internal class AuditingSelectorList : List<NamedTypeSelector>, IAuditingSelectorList
    {
        public bool RemoveByName(string name)
        {
            return RemoveAll(s => s.Name == name) > 0;
        }
    }
}
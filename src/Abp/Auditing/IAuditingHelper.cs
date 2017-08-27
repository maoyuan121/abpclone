using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Abp.Auditing
{
    /// <summary>
    /// ��ư�����
    /// </summary>
    public interface IAuditingHelper
    {
        /// <summary>
        /// �Ƿ�Ӧ�ñ��������־��Ϣ
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false);

        /// <summary>
        /// ���������־
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        AuditInfo CreateAuditInfo(MethodInfo method, object[] arguments);
        AuditInfo CreateAuditInfo(MethodInfo method, IDictionary<string, object> arguments);

        /// <summary>
        /// ���������־
        /// </summary>
        /// <param name="auditInfo"></param>
        void Save(AuditInfo auditInfo);
        Task SaveAsync(AuditInfo auditInfo);
    }
}
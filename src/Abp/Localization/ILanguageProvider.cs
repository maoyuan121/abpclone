using System.Collections.Generic;

namespace Abp.Localization
{
    /// <summary>
    /// �����ṩ��
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
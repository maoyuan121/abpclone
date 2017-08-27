using System.Collections.Generic;

namespace Abp.Localization
{
    /// <summary>
    /// ���Թ�����
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        /// ��ȡ��ǰ����
        /// </summary>
        LanguageInfo CurrentLanguage { get; }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
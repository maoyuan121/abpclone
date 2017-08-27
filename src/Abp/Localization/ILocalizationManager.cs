using System.Collections.Generic;
using Abp.Localization.Sources;

namespace Abp.Localization
{
    /// <summary>
    /// �����Թ�����
    /// </summary>
    public interface ILocalizationManager
    {
        /// <summary>
        /// ����name��ȡ��Ӧ�Ķ�������Դ
        /// </summary>
        /// <param name="name">Unique name of the localization source</param>
        /// <returns>The localization source</returns>
        ILocalizationSource GetSource(string name);

        /// <summary>
        /// ��ȡ���еĶ�������Դ
        /// </summary>
        /// <returns>List of sources</returns>
        IReadOnlyList<ILocalizationSource> GetAllSources();
    }
}
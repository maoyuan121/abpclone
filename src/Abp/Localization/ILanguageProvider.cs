using System.Collections.Generic;

namespace Abp.Localization
{
    /// <summary>
    /// 语言提供器
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// 获取所有语言
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
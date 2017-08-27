using System.Collections.Generic;

namespace Abp.Localization
{
    /// <summary>
    /// 语言管理器
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        /// 获取当前语言
        /// </summary>
        LanguageInfo CurrentLanguage { get; }

        /// <summary>
        /// 获取所有语言
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
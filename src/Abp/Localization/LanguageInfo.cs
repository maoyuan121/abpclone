namespace Abp.Localization
{
    /// <summary>
    /// 表示应用可以使用的语言
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>
        /// 语言的Code名
        /// 必须是合法的文化code
        /// Ex: "en-US" for American English, "tr-TR" for Turkey Turkish.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对外展示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 显示在UI上面的ICON
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否是默认语言
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Creates a new <see cref="LanguageInfo"/> object.
        /// </summary>
        /// <param name="name">
        /// Code name of the language.
        /// It should be valid culture code.
        /// Ex: "en-US" for American English, "tr-TR" for Turkey Turkish.
        /// </param>
        /// <param name="displayName">
        /// Display name of the language in it's original language.
        /// Ex: "English" for English, "T黵k鏴" for Turkish.
        /// </param>
        /// <param name="icon">An icon can be set to display on the UI</param>
        /// <param name="isDefault">Is this the default language?</param>
        public LanguageInfo(string name, string displayName, string icon = null, bool isDefault = false)
        {
            Name = name;
            DisplayName = displayName;
            Icon = icon;
            IsDefault = isDefault;
        }
    }
}
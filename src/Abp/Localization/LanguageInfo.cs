namespace Abp.Localization
{
    /// <summary>
    /// ��ʾӦ�ÿ���ʹ�õ�����
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>
        /// ���Ե�Code��
        /// �����ǺϷ����Ļ�code
        /// Ex: "en-US" for American English, "tr-TR" for Turkey Turkish.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����չʾ��
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// ��ʾ��UI�����ICON
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// �Ƿ���Ĭ������
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
        /// Ex: "English" for English, "T�rk�e" for Turkish.
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
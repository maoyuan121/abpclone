namespace Abp.Localization
{
    /// <summary>
    /// 多语言上下文
    /// </summary>
    public interface ILocalizationContext
    {
        /// <summary>
        /// 多语言管理器
        /// </summary>
        ILocalizationManager LocalizationManager { get; }
    }
}
namespace Abp.Localization
{
    /// <summary>
    /// ������������
    /// </summary>
    public interface ILocalizationContext
    {
        /// <summary>
        /// �����Թ�����
        /// </summary>
        ILocalizationManager LocalizationManager { get; }
    }
}
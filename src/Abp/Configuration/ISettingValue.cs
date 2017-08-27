namespace Abp.Configuration
{
    /// <summary>
    /// 配置值
    /// </summary>
    public interface ISettingValue
    {
        /// <summary>
        /// 配置唯一名
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// 配置值
        /// </summary>
        string Value { get; }
    }
}
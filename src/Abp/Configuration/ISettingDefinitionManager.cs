using System.Collections.Generic;

namespace Abp.Configuration
{
    /// <summary>
    /// 配置定义管理器
    /// 用来获取配置定义
    /// </summary>
    public interface ISettingDefinitionManager
    {
        /// <summary>
        /// 根据唯一名获取<see cref="SettingDefinition"/>对象
        /// Throws exception if can not find the setting.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <returns>The <see cref="SettingDefinition"/> object.</returns>
        SettingDefinition GetSettingDefinition(string name);

        /// <summary>
        /// 获取所有的配置定义对象
        /// </summary>
        /// <returns>All settings.</returns>
        IReadOnlyList<SettingDefinition> GetAllSettingDefinitions();
    }
}

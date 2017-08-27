using System;
using Abp.Localization;

namespace Abp.Configuration
{
    /// <summary>
    /// 定义一个配置
    /// A setting is used to configure and change behavior of the application.
    /// </summary>
    public class SettingDefinition
    {
        /// <summary>
        /// 配置的唯一名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 配置的对外展示名
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 配置的描述
        /// </summary>
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// 配置的作用范围
        /// Default value: <see cref="SettingScopes.Application"/>.
        /// </summary>
        public SettingScopes Scopes { get; set; }

        /// <summary>
        /// 是否继承自父范围级别
        /// Default: True.
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// 配置所属的分组
        /// </summary>
        public SettingDefinitionGroup Group { get; set; }

        /// <summary>
        /// 配置的默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 配置是否对外可见
        /// 有些配置对外展示可能会带来风险（例如Email服务器的密码）
        /// 默认: false.
        /// </summary>
        public bool IsVisibleToClients { get; set; }

        /// <summary>
        /// 用来存储和这个配置相关的用户对象
        /// Can be used to store a custom object related to this setting.
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// Creates a new <see cref="SettingDefinition"/> object.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="defaultValue">Default value of the setting</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="group">Group of this setting</param>
        /// <param name="description">A brief description for this setting</param>
        /// <param name="scopes">Scopes of this setting. Default value: <see cref="SettingScopes.Application"/>.</param>
        /// <param name="isVisibleToClients">Can clients see this setting and it's value. Default: false</param>
        /// <param name="isInherited">Is this setting inherited from parent scopes. Default: True.</param>
        /// <param name="customData">Can be used to store a custom object related to this setting</param>
        public SettingDefinition(
            string name, 
            string defaultValue, 
            ILocalizableString displayName = null, 
            SettingDefinitionGroup group = null, 
            ILocalizableString description = null, 
            SettingScopes scopes = SettingScopes.Application, 
            bool isVisibleToClients = false, 
            bool isInherited = true,
            object customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DefaultValue = defaultValue;
            DisplayName = displayName;
            Group = @group;
            Description = description;
            Scopes = scopes;
            IsVisibleToClients = isVisibleToClients;
            IsInherited = isInherited;
            CustomData = customData;
        }
    }
}

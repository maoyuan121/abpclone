using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Localization;

namespace Abp.Configuration
{
    /// <summary>
    /// 配置的分组，用来将配置划分为一个一个的组
    /// 一个组可以是另外一个组的子组
    /// </summary>
    public class SettingDefinitionGroup
    {
        /// <summary>
        /// 配置组的唯一名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 配置组的对外展示名
        /// </summary>
        public ILocalizableString DisplayName { get; private set; }

        /// <summary>
        /// 父组
        /// </summary>
        public SettingDefinitionGroup Parent { get; private set; }

        /// <summary>
        /// 子组集合
        /// </summary>
        public IReadOnlyList<SettingDefinitionGroup> Children
        {
            get { return _children.ToImmutableList(); }
        }
        private readonly List<SettingDefinitionGroup> _children;

        /// <summary>
        /// Creates a new <see cref="SettingDefinitionGroup"/> object.
        /// </summary>
        /// <param name="name">Unique name of the setting group</param>
        /// <param name="displayName">Display name of the setting</param>
        public SettingDefinitionGroup(string name, ILocalizableString displayName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name parameter is invalid! It can not be null or empty or whitespace", "name"); //TODO: Simpify throwing such exceptions
            }

            Name = name;
            DisplayName = displayName;
            _children = new List<SettingDefinitionGroup>();
        }

        /// <summary>
        /// Adds a <see cref="SettingDefinitionGroup"/> as child of this group.
        /// </summary>
        /// <param name="child">Child to be added</param>
        /// <returns>This child group to be able to add more child</returns>
        public SettingDefinitionGroup AddChild(SettingDefinitionGroup child)
        {
            if (child.Parent != null)
            {
                throw new AbpException("Setting group " + child.Name + " has already a Parent (" + child.Parent.Name + ").");
            }

            _children.Add(child);
            child.Parent = this;
            return this;
        }
    }
}
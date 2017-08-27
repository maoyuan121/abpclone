using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Application.Features;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Abp.Authorization
{
    /// <summary>
    /// 代表一个权限
    /// A permission is used to restrict functionalities of the application from unauthorized users.
    /// </summary>
    public sealed class Permission
    {
        /// <summary>
        /// 父权限
        /// 如果有的话，那么必须被授予了父权限才能授予这个权限
        /// </summary>
        public Permission Parent { get; private set; }

        /// <summary>
        /// 权限的唯一名
        /// This is the key name to grant permissions.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 权限对外展示名
        /// This can be used to show permission to the user.
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 权限的描述
        /// </summary>
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// 标识这个权限是应用在租户上的，还是Host上的，这个枚举是Flags的
        /// </summary>
        public MultiTenancySides MultiTenancySides { get; set; }

        /// <summary>
        /// 权限所依赖的Feature
        /// </summary>
        public IFeatureDependency FeatureDependency { get; set; }

        /// <summary>
        /// 子权限
        /// </summary>
        public IReadOnlyList<Permission> Children => _children.ToImmutableList();
        private readonly List<Permission> _children;

        /// <summary>
        /// Creates a new Permission.
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="description">A brief description for this permission</param>
        /// <param name="multiTenancySides">Which side can use this permission</param>
        /// <param name="featureDependency">Depended feature(s) of this permission</param>
        public Permission(
            string name,
            ILocalizableString displayName = null,
            ILocalizableString description = null,
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant,
            IFeatureDependency featureDependency = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
            DisplayName = displayName;
            Description = description;
            MultiTenancySides = multiTenancySides;
            FeatureDependency = featureDependency;

            _children = new List<Permission>();
        }

        /// <summary>
        /// 添加子权限
        /// A child permission can be granted only if parent is granted.
        /// </summary>
        /// <returns>Returns newly created child permission</returns>
        public Permission CreateChildPermission(
            string name, 
            ILocalizableString displayName = null, 
            ILocalizableString description = null, 
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant,
            IFeatureDependency featureDependency = null)
        {
            var permission = new Permission(name, displayName, description, multiTenancySides, featureDependency) { Parent = this };
            _children.Add(permission);
            return permission;
        }

        public override string ToString()
        {
            return string.Format("[Permission: {0}]", Name);
        }
    }
}

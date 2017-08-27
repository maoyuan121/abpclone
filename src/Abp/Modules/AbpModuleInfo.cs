using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Abp.Modules
{
    /// <summary>
    /// 模块信息类
    /// </summary>
    public class AbpModuleInfo
    {
        /// <summary>
        /// 模块所在的程序集
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// 模块类
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 模块实例
        /// </summary>
        public AbpModule Instance { get; }

        /// <summary>
        /// 这个模块是否是作为插件载入的
        /// </summary>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// 这个模块所依赖的模块
        /// </summary>
        public List<AbpModuleInfo> Dependencies { get; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        public AbpModuleInfo([NotNull] Type type, [NotNull] AbpModule instance, bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            Type = type;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;
            Assembly = Type.Assembly;

            Dependencies = new List<AbpModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ??
                   Type.FullName;
        }
    }
}
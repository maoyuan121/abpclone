using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Abp.Modules
{
    /// <summary>
    /// ģ����Ϣ��
    /// </summary>
    public class AbpModuleInfo
    {
        /// <summary>
        /// ģ�����ڵĳ���
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// ģ����
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// ģ��ʵ��
        /// </summary>
        public AbpModule Instance { get; }

        /// <summary>
        /// ���ģ���Ƿ�����Ϊ��������
        /// </summary>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// ���ģ����������ģ��
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
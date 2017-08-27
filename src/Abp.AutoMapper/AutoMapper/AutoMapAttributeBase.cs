using System;
using AutoMapper;

namespace Abp.AutoMapper
{
    /// <summary>
    /// AutoMapAtturbute的基类
    /// </summary>
    public abstract class AutoMapAttributeBase : Attribute
    {
        /// <summary>
        /// 目标类型
        /// </summary>
        public Type[] TargetTypes { get; private set; }

        protected AutoMapAttributeBase(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public abstract void CreateMap(IMapperConfigurationExpression configuration, Type type);
    }
}
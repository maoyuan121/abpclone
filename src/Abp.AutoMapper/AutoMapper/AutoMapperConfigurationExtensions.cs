using System;
using System.Reflection;
using AutoMapper;

namespace Abp.AutoMapper
{
    internal static class AutoMapperConfigurationExtensions
    {
        /// <summary>
        /// 找到被AutoMapAttributeBase修饰的类，CreateMap
        /// </summary>
        /// <param name="configuration"></param> 
        /// <param name="type"></param>
        public static void CreateAutoAttributeMaps(this IMapperConfigurationExpression configuration, Type type)
        {
            foreach (var autoMapAttribute in type.GetCustomAttributes<AutoMapAttributeBase>())
            {
                autoMapAttribute.CreateMap(configuration, type);
            }
        }
    }
}
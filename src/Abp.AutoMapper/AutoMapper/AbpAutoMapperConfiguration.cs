using System;
using System.Collections.Generic;
using AutoMapper;

namespace Abp.AutoMapper
{
    /// <summary>
    /// automapper的配置文件
    /// </summary>
    public class AbpAutoMapperConfiguration : IAbpAutoMapperConfiguration
    {
        /// <summary>
        /// automapper的配置表达式
        /// </summary>
        public List<Action<IMapperConfigurationExpression>> Configurators { get; }

        public AbpAutoMapperConfiguration()
        {
            Configurators = new List<Action<IMapperConfigurationExpression>>();
        }
    }
}
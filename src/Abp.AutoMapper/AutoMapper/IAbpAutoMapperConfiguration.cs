using System;
using System.Collections.Generic;
using AutoMapper;

namespace Abp.AutoMapper
{
    /// <summary>
    /// automapper的配置文件
    /// </summary>
    public interface IAbpAutoMapperConfiguration
    {
        /// <summary>
        /// automapper的配置表达式
        /// </summary>
        List<Action<IMapperConfigurationExpression>> Configurators { get; }
    }
}
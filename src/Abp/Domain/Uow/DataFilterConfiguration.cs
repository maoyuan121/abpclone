using System.Collections.Generic;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 数据过滤器的配置
    /// </summary>
    public class DataFilterConfiguration
    {
        /// <summary>
        /// 过滤器名
        /// </summary>
        public string FilterName { get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// 过滤器的参数
        /// </summary>
        public IDictionary<string, object> FilterParameters { get; }

        public DataFilterConfiguration(string filterName, bool isEnabled)
        {
            FilterName = filterName;
            IsEnabled = isEnabled;
            FilterParameters = new Dictionary<string, object>();
        }

        internal DataFilterConfiguration(DataFilterConfiguration filterToClone, bool? isEnabled = null)
            : this(filterToClone.FilterName, isEnabled ?? filterToClone.IsEnabled)
        {
            foreach (var filterParameter in filterToClone.FilterParameters)
            {
                FilterParameters[filterParameter.Key] = filterParameter.Value;
            }
        }
    }
}
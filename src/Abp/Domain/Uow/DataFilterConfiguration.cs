using System.Collections.Generic;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ���ݹ�����������
    /// </summary>
    public class DataFilterConfiguration
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string FilterName { get; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// �������Ĳ���
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
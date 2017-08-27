using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ��ȡ/����uow��Ĭ������
    /// </summary>
    internal class UnitOfWorkDefaultOptions : IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// ����Χ
        /// </summary>
        public TransactionScopeOption Scope { get; set; }

        /// <inheritdoc/>
        public bool IsTransactional { get; set; }

        /// <summary>
        /// ���ó�ʱʱ��
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// ������뼶��
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// �������������ļ�����
        /// </summary>
        public IReadOnlyList<DataFilterConfiguration> Filters
        {
            get { return _filters; }
        }
        private readonly List<DataFilterConfiguration> _filters;

        /// <summary>
        /// ע�������
        /// ����������ӵ������ļ�����
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="isEnabledByDefault"></param>
        public void RegisterFilter(string filterName, bool isEnabledByDefault)
        {
            if (_filters.Any(f => f.FilterName == filterName))
            {
                throw new AbpException("There is already a filter with name: " + filterName);
            }

            _filters.Add(new DataFilterConfiguration(filterName, isEnabledByDefault));
        }

        /// <summary>
        /// ����һ��������������
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="isEnabledByDefault"></param>
        public void OverrideFilter(string filterName, bool isEnabledByDefault)
        {
            _filters.RemoveAll(f => f.FilterName == filterName);
            _filters.Add(new DataFilterConfiguration(filterName, isEnabledByDefault));
        }

        public UnitOfWorkDefaultOptions()
        {
            _filters = new List<DataFilterConfiguration>();
            IsTransactional = true;
            Scope = TransactionScopeOption.Required;
        }
    }
}
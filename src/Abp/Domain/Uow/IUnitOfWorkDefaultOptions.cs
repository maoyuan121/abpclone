using System;
using System.Collections.Generic;
using System.Transactions;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ��ȡ/����uow��Ĭ������
    /// </summary>
    public interface IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// ����Χ
        /// </summary>
        TransactionScopeOption Scope { get; set; }

        /// <summary>
        /// Should unit of works be transactional.
        /// Default: true.
        /// </summary>
        bool IsTransactional { get; set; }

        /// <summary>
        /// ���ó�ʱʱ��
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// ������뼶��
        /// This is used if <see cref="IsTransactional"/> is true.
        /// </summary>
        IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// �������������ļ�����
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// ע���������uow
        /// </summary>
        /// <param name="filterName">Name of the filter.</param>
        /// <param name="isEnabledByDefault">Is filter enabled by default.</param>
        void RegisterFilter(string filterName, bool isEnabledByDefault);

        /// <summary>
        /// ����һ��������������
        /// </summary>
        /// <param name="filterName">Name of the filter.</param>
        /// <param name="isEnabledByDefault">Is filter enabled by default.</param>
        void OverrideFilter(string filterName, bool isEnabledByDefault);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// ��̨�����洢��
    /// </summary>
    public interface IBackgroundJobStore
    {
        /// <summary>
        /// ����һ��������Ϣ
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task InsertAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// Gets waiting jobs. It should get jobs based on these:
        /// Conditions: !IsAbandoned And NextTryTime &lt;= Clock.Now.
        /// Order by: Priority DESC, TryCount ASC, NextTryTime ASC.
        /// Maximum result: <paramref name="maxResultCount"/>.
        /// </summary>
        /// <param name="maxResultCount">Maximum result count.</param>
        Task<List<BackgroundJobInfo>> GetWaitingJobsAsync(int maxResultCount);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task DeleteAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task UpdateAsync(BackgroundJobInfo jobInfo);
    }
}
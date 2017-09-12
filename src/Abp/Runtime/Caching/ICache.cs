using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// ����һ�����������洢����ͨ��key��ȡ������
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// �����Ψһ��
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Ĭ�ϵĻ������ʱ��
        /// Ĭ��ֵ: 60����
        /// ������configuration�޸�
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// ����ľ��Թ���ʱ��
        /// Ĭ��ֵ��null
        /// </summary>
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        /// <summary>
        /// ��ȡһ�������cache item��
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="factory">���û�û���������������Ĺ�������</param>
        /// <returns>������</returns>
        object Get(string key, Func<string, object> factory);

        /// <summary>
        /// ��ȡһ�������cache item��
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="factory">���û�û���������������Ĺ�������</param>
        /// <returns>������</returns>
        Task<object> GetAsync(string key, Func<string, Task<object>> factory);

        /// <summary>
        /// ��ȡһ����������û�еĻ�����null
        /// </summary>
        /// <param name="key">��</param>
        /// <returns>���������null</returns>
        object GetOrDefault(string key);

        /// <summary>
        /// ��ȡһ����������û�еĻ�����null
        /// </summary>
        /// <param name="key">��</param>
        /// <returns>���������null</returns>
        Task<object> GetOrDefaultAsync(string key);

        /// <summary>
        /// ����һ��������
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="value">ֵ</param>
        /// <param name="slidingExpireTime">����ʱ��</param>
        /// <param name="absoluteExpireTime">���Թ���ʱ��</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// ����һ��������
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="value">ֵ</param>
        /// <param name="slidingExpireTime">����ʱ��</param>
        /// <param name="absoluteExpireTime">���Թ���ʱ��</param>
        Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// ���һ��������
        /// </summary>
        /// <param name="key">��</param>
        void Remove(string key);

        /// <summary>
        /// ���һ��������
        /// </summary>
        /// <param name="key">��</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// ���������������item
        /// </summary>
        void Clear();

        /// <summary>
        /// ���������������item
        /// </summary>
        Task ClearAsync();
    }
}
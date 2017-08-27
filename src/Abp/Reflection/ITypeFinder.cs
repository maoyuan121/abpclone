using System;

namespace Abp.Reflection
{
    /// <summary>
    /// 类查找器
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 根据条件查找类
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Type[] Find(Func<Type, bool> predicate);

        /// <summary>
        /// 查找所有的类
        /// </summary>
        /// <returns></returns>
        Type[] FindAll();
    }
}
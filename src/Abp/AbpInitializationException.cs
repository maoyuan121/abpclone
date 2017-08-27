using System;
using System.Runtime.Serialization;

namespace Abp
{
    /// <summary>
    /// 日过在ABP的初始化过程中发生异常，那么抛出这个一场
    /// </summary>
    [Serializable]
    public class AbpInitializationException : AbpException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AbpInitializationException()
        {

        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public AbpInitializationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AbpInitializationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AbpInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

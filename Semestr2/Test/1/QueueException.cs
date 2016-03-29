using System;

namespace Problem1
{
    /// <summary>
    /// Exception for queue
    /// </summary>
    [Serializable]
    public class QueueException : ApplicationException
    {
        public QueueException() { }
        public QueueException(string message) : base(message) { }
        public QueueException(string message, Exception inner) : base(message, inner)
        { }
        protected QueueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
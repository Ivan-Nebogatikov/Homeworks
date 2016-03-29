using System;

namespace Problem1
{
    /// <summary>
    /// Exception for pop from empty queue
    /// </summary>
    [Serializable]
    public class EmptyQueueException : QueueException
    {
        public EmptyQueueException() { }
        public EmptyQueueException(string message) : base(message) { }
        public EmptyQueueException(string message, Exception inner) : base(message, inner)
        { }
        protected EmptyQueueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
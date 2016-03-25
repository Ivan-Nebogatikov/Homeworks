using System;

namespace Problem1
{
    /// <summary>
    /// Exception for wrong number of priority
    /// </summary>
    [Serializable]
    public class OutOfPriorityNumberException : QueueException
    {
        public OutOfPriorityNumberException() { }
        public OutOfPriorityNumberException(string message) : base(message) { }
        public OutOfPriorityNumberException(string message, Exception inner) : base(message, inner)
        { }
        protected OutOfPriorityNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
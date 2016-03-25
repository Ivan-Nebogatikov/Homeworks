using System;

namespace Problem1
{
    /// <summary>
    /// Exception for trying get out of bounds element
    /// </summary>
    [Serializable]
    public class OutOfBoundsOfListException : ListException
    {
        public OutOfBoundsOfListException() { }
        public OutOfBoundsOfListException(string message) : base(message) { }
        public OutOfBoundsOfListException(string message, Exception inner) : base(message, inner)
        { }
        protected OutOfBoundsOfListException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}

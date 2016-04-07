using System;

namespace Problem1and2
{
    /// <summary>
    /// Stack is empty exception
    /// </summary>
    [Serializable]
    public class EmptyStackException : ApplicationException
    {
        public EmptyStackException() { }
        public EmptyStackException(string message) : base(message) { }
        public EmptyStackException(string message, Exception inner) : base(message, inner)
        { }
        protected EmptyStackException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}


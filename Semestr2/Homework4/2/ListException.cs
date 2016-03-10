using System;

namespace Problem2
{
    /// <summary>
    /// Main list exception
    /// </summary>
    [Serializable]
    public class ListException : ApplicationException
    {
        public ListException() { }
        public ListException(string message) : base(message) { }
        public ListException(string message, Exception inner) : base(message, inner)
        { }
        protected ListException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}


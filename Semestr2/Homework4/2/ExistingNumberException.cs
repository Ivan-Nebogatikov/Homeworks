using System;

namespace Problem2
{
    /// <summary>
    /// Exception for trying add existing number to unique list
    /// </summary>
    [Serializable]
    public class ExistingNumberException : ListException
    {
        public ExistingNumberException() { }
        public ExistingNumberException(string message) : base(message) { }
        public ExistingNumberException(string message, Exception inner) : base(message, inner)
        { }
        protected ExistingNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}

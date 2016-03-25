using System;

namespace Problem1
{
    /// <summary>
    /// Exception for deleting not excisting element from list
    /// </summary>
    public class RemoveNotExistingElementException : ListException
    {
        public RemoveNotExistingElementException() { }
        public RemoveNotExistingElementException(string message) : base(message) { }
        public RemoveNotExistingElementException(string message, Exception inner) : base(message, inner)
        { }
        protected RemoveNotExistingElementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}

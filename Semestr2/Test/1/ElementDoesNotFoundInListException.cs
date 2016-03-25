using System;

namespace Problem1
{
    /// <summary>
    /// Exception for Element does not found in list
    /// </summary>
    [Serializable]
    public class ElementDoesNotFoundInListException : ListException
    {
        public ElementDoesNotFoundInListException() { }
        public ElementDoesNotFoundInListException(string message) : base(message) { }
        public ElementDoesNotFoundInListException(string message, Exception inner) : base(message, inner)
        { }
        protected ElementDoesNotFoundInListException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}

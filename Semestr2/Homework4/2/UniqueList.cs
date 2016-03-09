namespace Problem2
{
    /// <summary>
    /// Unique List class
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Add new elemet to Unique list; Throw ExistingNumberException() is number is exist in list
        /// </summary>
        /// <param name="newElement"> New element to list </param>
        public override void Add(int newElement)
        {
            try
            {
                IndexOf(newElement);
                throw new ExistingNumberException();
            }
            catch (ElementDoesNotFoundInListException)
            {
                base.Add(newElement);
            }            
        }
    }
}

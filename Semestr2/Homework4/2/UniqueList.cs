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
            if (!Contains(newElement))
                base.Add(newElement);
            else
                throw new ExistingNumberException();       
        }
    }
}

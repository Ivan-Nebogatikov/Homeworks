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
            Node temp = head;
            while (temp != null)
            {
                if (temp.Value == newElement)
                    throw new ExistingNumberException();
                temp = temp.Next;
            }
            Node newNode = new Node(newElement);
            if (size == 0)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            ++size;
        }
    }
}

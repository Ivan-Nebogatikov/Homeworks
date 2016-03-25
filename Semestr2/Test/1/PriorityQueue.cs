namespace Problem1
{
    /// <summary>
    /// Class for Priority queue
    /// </summary>
    public class PriorityQueue : IPriorityQueue
    {
        private List[] list;
        private const int defaultMaxPriority = 100;

        /// <summary>
        /// Priority queue constructor; Throw OutOfPriorityNumberException() if maxPriority < 0
        /// </summary>
        public PriorityQueue(int maxPriority)
        {
            if (maxPriority < 0)
                throw new OutOfPriorityNumberException();
            list = new List[maxPriority];
            for (var i = 0; i < maxPriority; ++i)
                list[i] = new List();
        }

        /// <summary>
        /// Constructor with default maxPriority
        /// </summary>
        public PriorityQueue() : this(defaultMaxPriority)
        {
        }

        /// <summary>
        /// Push new element to priority queue; Throw OutOfPriorityNumberException() if priority is wrong
        /// </summary>
        /// <param name="value"> Value of new element </param>
        /// <param name="priority"> Priority of new element </param>
        public void Enqueue(int value, int priority)
        {
            if (priority < 0 || priority > list.Length)
                throw new OutOfPriorityNumberException();
            list[priority].Add(value);
        }

        /// <summary>
        /// Get highest priority element from queue
        /// </summary>
        /// <returns> Element value or EmptyQueueException() if queue is empty </returns>
        public int Dequeue()
        {
            for (var i = list.Length - 1; i >= 0; --i)
            {
                if (list[i].GetLength() != 0)
                {
                    var temp = list[i].GetElement(list[i].GetLength() - 1);
                    list[i].Remove(list[i].GetLength() - 1);
                    return temp;
                }
            }
            throw new EmptyQueueException();
        }

        /// <summary>
        /// Check is queue is empty
        /// </summary>
        /// <returns> True if queue is empty </returns>
        public bool IsEmpty()
        {
            for (var i = list.Length - 1; i >= 0; --i)
                if (list[i].GetLength() != 0)
                    return false;
            return true;
        }
    }
}

namespace Problem1
{
    /// <summary>
    /// Interfacce for priority queue
    /// </summary>
    public interface IPriorityQueue
    {
        /// <summary>
        /// Push new element to priority queue; Throw OutOfPriorityNumberException() if priority is wrong
        /// </summary>
        /// <param name="value"> Value of new element </param>
        /// <param name="priority"> Priority of new element </param>
        void Enqueue(int value, int priority);

        /// <summary>
        /// Get highest priority element from queue
        /// </summary>
        /// <returns> Element value or EmptyQueueException() if queue is empty </returns>
        int Dequeue();

        /// <summary>
        /// Check is queue is empty
        /// </summary>
        /// <returns> True if queue is empty </returns>
        bool IsEmpty();
    }
}
namespace InerfaceStack
{
    /// <summary>
    /// Interface for work with Stack
    /// </summary>
    interface IStack
    {
        void Push(int newNumber);

        int Pop();

        bool IsEmpty();
    }
}

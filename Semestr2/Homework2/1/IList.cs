namespace InterfaceList
{
    /// <summary>
    /// Interface for work with List
    /// </summary>
    interface IList
    {
        void Add(int newElement);

        int IndexOf(int element);

        bool Remove(int element);

        int GetLenght();

        int GetElement(int index);
    }
}

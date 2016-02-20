using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceList
{
    /// <summary>
    /// Interface for work with List
    /// </summary>
    interface IList
    {
        void Add(string newElement);
        
        int IndexOf(string element);

        bool Remove(string element);

        int GetLenght();

        string GetElement(int index);
    }
}

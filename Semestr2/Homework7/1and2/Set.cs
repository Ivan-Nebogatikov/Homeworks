using System.Linq;
using System.Xml;

namespace Problem1and2
{
    /// <summary>
    /// Main set class
    /// </summary>
    public class Set<T>
    {
        private List<T> set; 

        /// <summary>
        /// Set constructor
        /// </summary>
        public Set()
        {
            set = new List<T>();
        }

        /// <summary>
        /// Add new element to set
        /// </summary>
        /// <param name="newElement"> Value of new element </param>
        public void Add(T newElement) => set.Add(newElement);

        /// <summary>
        /// Delete element from set
        /// </summary>
        /// <param name="element"> Element value to delete </param>
        public void Delete(T element) => set.Remove(element);

        private List<T> GetAsList() => set;

        /// <summary>
        /// Is element contains in set
        /// </summary>
        /// <param name="element"> Element value </param>
        /// <returns> True if element exist in set </returns>
        public bool Contains(T element) => set.Contains(element);

        /// <summary>
        /// Intersetction of two sets
        /// </summary>
        /// <param name="setForIntersection"> Second set for intersection </param>
        /// <returns> Set of intersetion </returns>
        public Set<T> Intersection(Set<T> setForIntersection)
        {
            var newSet = new Set<T>();
            var tempList = new List<T>();
            foreach (var value in setForIntersection.GetAsList())
                tempList.Add(value);
            foreach (var value in set.Cast<T>().Where(value => tempList.Contains(value)))
            {
                newSet.Add(value);
                tempList.Remove(value);
            }
            return newSet;
        }

        /// <summary>
        /// Union of two sets
        /// </summary>
        /// <param name="setForUnion"> Second set for union </param>
        /// <returns> Union of two sets</returns>
        public Set<T> Union(Set<T> setForUnion)
        {
            var newSet = new Set<T>();
            var tempList = new List<T>();
            foreach (var value in setForUnion.GetAsList())
                tempList.Add(value);
            foreach (var value in set)
            {
                if (tempList.Contains(value))
                    tempList.Remove(value);
                newSet.Add(value);
            }
            foreach (var value in tempList)
                newSet.Add(value);
            return newSet;
        }
    }
}

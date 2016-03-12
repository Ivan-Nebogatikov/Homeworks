using System;

namespace Problem1and2and3
{
    /// <summary>
    /// Class for list functions
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Map function for list
        /// </summary>
        /// <param name="list"> List for change </param>
        /// <param name="function"> Changing function </param>
        /// <returns> Changed list </returns>
        public static List Map(List list, Func<int, int> function)
        {
            for (int i = 0; i < list.GetLength(); ++i)
                list.SetNewElementValue(i, function(list.GetElement(i)));
            return list;
        }

        /// <summary>
        /// Filter list function
        /// </summary>
        /// <param name="list"> List for checking </param>
        /// <param name="function"> Function for filter </param>
        /// <returns> Filtered list </returns>
        public static List Filter(List list, Func<int, bool> function)
        {
            List newList = new List();
            for (int i = 0; i < list.GetLength(); ++i)
                if (function(list.GetElement(i)))
                    newList.Add(list.GetElement(i));
            return newList;
        }

        /// <summary>
        /// Fold list function
        /// </summary>
        /// <param name="list"> List for calculating </param>
        /// <param name="startValue"> Start value of calculating </param>
        /// <param name="function"> Functiong for calculating </param>
        /// <returns> Result of calculating </returns>
        public static int Fold(List list, int startValue, Func<int, int, int> function)
        {
            for (int i = 0; i < list.GetLength(); ++i)
                startValue = function(startValue, list.GetElement(i));
            return startValue;
        }
    }
}

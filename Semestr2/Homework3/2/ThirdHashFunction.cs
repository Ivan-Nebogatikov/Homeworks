﻿using System;

namespace Problem2
{
    /// <summary>
    /// Class for third hash function
    /// </summary>
    public class ThirdHashFunction : AbstractHashFunction
    {
        /// <summary>
        /// Calculating hash of expression
        /// </summary>
        /// <param name="expression"> Expression to hashing </param>
        /// <param name="size"> Size of hash table </param>
        /// <returns> Hash of expression </returns>
        public int Hash(string expression, int size)
        {
            return Convert.ToInt32(expression[expression.Length - 1]) % size;
        }
    }
}

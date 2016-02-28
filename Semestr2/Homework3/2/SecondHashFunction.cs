namespace Problem2
{
    /// <summary>
    /// Class for second hash function
    /// </summary>
    public class SecondHashFunction : AbstractHashFunction
    {
        /// <summary>
        /// Calculating hash of expression
        /// </summary>
        /// <param name="expression"> Expression to hashing </param>
        /// <param name="size"> Size of hash table </param>
        /// <returns> Hash of expression </returns>
        public int Hash(string expression, int size)
        {
            int hash = 0;
            if (expression.Length >= 3)
                hash = (expression[0] + expression[1] + expression[2]) / 3;
            else
                hash = expression[0];
            return hash % size;
        }
    }
}

namespace Problem2
{
    /// <summary>
    /// Interface for work with different hash funcions
    /// </summary>
    public interface AbstractHashFunction
    {
        /// <summary>
        /// Get hash code of expression
        /// </summary>
        /// <param name="expression"> String for calculating hash </param>
        /// <param name="size"> Size of hash table </param>
        /// <returns> Hash code of expression </returns>
        int Hash(string expression, int size);
    }
}

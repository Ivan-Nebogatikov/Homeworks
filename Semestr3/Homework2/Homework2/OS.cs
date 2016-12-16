namespace Homework2
{
    /// <summary>
    /// Class for Operation systems
    /// </summary>
    public class OS
    {
        /// <summary>
        /// Chance of infection
        /// </summary>
        public double ProbabilityOfInfection { get; set; }

        /// <summary>
        /// OS constructor
        /// </summary>
        /// <param name="probability"> Probability of infection </param>
        public OS(double probability)
        {
            ProbabilityOfInfection = probability;
        }
    }
}

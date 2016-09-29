using System.Collections.Generic;

namespace Homework2
{
    /// <summary>
    /// Class for computers in network
    /// </summary>
    public class Computer
    {
        private readonly OS os;

        /// <summary>
        /// Is this computer infected
        /// </summary>
        public bool Infected { get; set; }

        /// <summary>
        /// List of neighbours of this computer in the network
        /// </summary>
        public List<int> Neighbours { get; set; }

        /// <summary>
        /// Network computer constructor
        /// </summary>
        /// <param name="os"> Type of OS </param>
        /// <param name="infection"> Is infected in default </param>
        /// <param name="neigh"> List of indexes of heighbours computers </param>
        public Computer(OS os, bool infection, List<int> neigh)
        {
            this.os = os;
            Infected = infection;
            Neighbours = neigh;
        }

        /// <summary>
        /// Returns probability of infetion of this os type
        /// </summary>
        /// <returns> Value from 0 to 1</returns>
        public double GetOSProbability() => os.ProbabilityOfInfection;
    }
}

using System;
using System.Collections.Generic;

namespace Homework2
{
    /// <summary>
    /// Class for network realization
    /// </summary>
    public class Network
    {
        private List<Computer> computers;

        /// <summary>
        /// Network constructor
        /// </summary>
        /// <param name="computers"> List of computers in the network </param>
        public Network(List<Computer> computers)
        {
            this.computers = computers;
        }

        /// <summary>
        /// Starting Network infection
        /// </summary>
        public void StartNetwork()
        {
            while (!Checking())
            {
                Infections();
            }
        }

        private void Infections()
        {
            foreach (var computer in computers)
            {
                foreach (var neighbour in computer.Neighbours)
                {
                    if (new Random().NextDouble() < computers[neighbour].GetOSProbability())
                        computers[neighbour].Infected = true;
                }
            }
        }

        private bool Checking()
        {
            int count = 0;
            for (int i = 0; i < computers.Count; ++i)
            {
                if (computers[i].Infected)
                    ++count;
                Console.WriteLine("Компьтер № " + i + " " + (computers[i].Infected ? " ": "не ") + "заражен");
            }
            Console.WriteLine();
            return count == computers.Count;
        }
    }
}

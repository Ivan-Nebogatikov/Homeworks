using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    /// <summary>
    /// Class for network realization
    /// </summary>
    public class Network
    {
        /// <summary>
        /// Computers in the system
        /// </summary>
        public List<Computer> Computers { get; }

        private readonly Random random = new Random();

        /// <summary>
        /// Network constructor
        /// </summary>
        /// <param name="computers"> List of computers in the network </param>
        public Network(List<Computer> computers)
        {
            Computers = computers;
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

        /// <summary>
        /// Do infection move
        /// </summary>
        public void Infections()
        {
            var infectedComputers = Computers.Where(computer => computer.Infected).ToList();
            foreach (var computer in infectedComputers)
            {
                foreach (var neighbour in computer.Neighbours)
                {
                    if (random.NextDouble() <= Computers[neighbour].GetOSProbability())
                        Computers[neighbour].Infected = true;
                }
            }
        }
        
        private bool Checking()
        {
            int count = 0;
            for (int i = 0; i < Computers.Count; ++i)
            {
                if (Computers[i].Infected)
                    ++count;
                Console.WriteLine("Компьтер № " + i + " " + (Computers[i].Infected ? " " : "не ") + "заражен");
            }
            Console.WriteLine();
            return count == Computers.Count || count == 0;
        }
    }
}
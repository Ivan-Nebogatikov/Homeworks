using System.Collections.Generic;
using System.Linq;

namespace Homework3
{
    /// <summary>
    /// Class for interaction with robots 
    /// </summary>
    public class Robots
    {
        private readonly Graph graph;
        private readonly List<int> robots;

        /// <summary>
        /// Constructor for robots
        /// </summary>
        /// <param name="graph"> Graph for robots </param>
        /// <param name="positions"> Robots positions </param>
        public Robots(Graph graph, int[] positions)
        {
            this.graph = graph;
            robots = new List<int>(positions.Length);
            foreach (var robot in positions)
                robots.Add(robot);
        }

        private bool HasSameParity()
        {
            var dist = graph.WayToVertices(robots[0]);
            return robots.All(robot => (dist[robot] + dist[robots[0]])%2 == 0);
        }

        /// <summary>
        /// Checking will robots be destroyed
        /// </summary>
        /// <returns> True if robots will be destroyed </returns>
        public bool WillBeDestroyed() => graph.HasCycleWithOddLenght() || HasSameParity();
    }
}

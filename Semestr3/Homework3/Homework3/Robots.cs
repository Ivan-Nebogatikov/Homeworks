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
            var tempRobots = new List<int>(robots);
            var dist = graph.WayToVertices(tempRobots[0]);
            tempRobots.RemoveAll(robot => dist[robot] % 2 == 0);
            if (tempRobots.Count == 0)
            {
                return true;
            }
            if (tempRobots.Count == 1)
            {
                return false;
            }
            dist = graph.WayToVertices(tempRobots[0]);
            tempRobots.RemoveAll(robot => dist[robot] % 2 == 0);
            return tempRobots.Count == 0;
        }

        /// <summary>
        /// Checking will robots be destroyed
        /// </summary>
        /// <returns> True if robots will be destroyed </returns>
        public bool WillBeDestroyed() 
            => (robots.Count > 1) && (graph.HasCycleWithOddLenght() || HasSameParity());
    }
}

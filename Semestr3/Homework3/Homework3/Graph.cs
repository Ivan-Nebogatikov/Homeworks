using System.Collections.Generic;

namespace Homework3
{
    /// <summary>
    /// Class for graph realization
    /// </summary>
    public class Graph
    {
        private readonly List<int>[] neighbours;

        /// <summary>
        /// Graph constructor
        /// </summary>
        /// <param name="vertexNumber"> Vertex number in graph </param>
        public Graph(int vertexNumber)
        {
            neighbours = new List<int>[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
            {
                neighbours[i] = new List<int>();
            }
        }

        /// <summary>
        /// Adds neighbours for graph vertex and this vertex as neighbours of list items
        /// </summary>
        /// <param name="vertex"> Current vertex </param>
        /// <param name="newNeigh"> List of vertex neighbours </param>
        public void AddNeighbours(int vertex, List<int> newNeigh)
        {
            foreach (var neight in newNeigh)
            {
                neighbours[vertex].Add(neight);
                neighbours[neight].Add(vertex);
            }
        }


        private void DFS(int vert, int from, ref int[] mark, int step, ref bool isCycleFound)
        {
            if (mark[vert] != 0)
                return;
            ++step;
            mark[vert] = step;
            foreach (var vertex in neighbours[vert])
            {
                if (vertex != from)
                {
                    if (mark[vertex] > 0 && mark[vertex] % 2 == mark[vert] % 2)
                        isCycleFound = true;
                    DFS(vertex, vert, ref mark, step, ref isCycleFound);
                }
            }
        }

        /// <summary>
        /// Checks is graph contains cycle with odd lenght
        /// </summary>
        /// <returns> True if contains </returns>
        public bool HasCycleWithOddLenght()
        {
            var mark = new int[neighbours.Length];
            int step = 1;
            bool isSycleFound = false;
            DFS(0, -1, ref mark, step, ref isSycleFound);
            return isSycleFound;
        }

        /// <summary>
        /// Method for getting way from one vertex to others without cycles
        /// </summary>
        /// <param name="vertex"> Start vertex </param>
        /// <returns> Array of distance </returns>
        public int[] WayToVertices(int vertex)
        {
            var mark = new int[neighbours.Length];
            int step = 0;
            bool isSycleFound = false;
            DFS(vertex, -1, ref mark, step, ref isSycleFound);
            for (int i = 0; i < neighbours.Length; ++i)
                --mark[i];
            return mark;
        }
    }
}

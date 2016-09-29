using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework3.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        public void HasCycleWithOddLenghtTest()
        {
            var graph = new Graph(6);
            graph.AddNeighbours(0, new List<int>() { 1 });
            graph.AddNeighbours(1, new List<int>() { 2, 5, 0 });
            graph.AddNeighbours(2, new List<int>() { 1, 3 });
            graph.AddNeighbours(3, new List<int>() { 2, 4 });
            graph.AddNeighbours(4, new List<int>() { 3, 5 });
            graph.AddNeighbours(5, new List<int>() { 1, 4 });
            Assert.IsTrue(graph.HasCycleWithOddLenght());
        }

        [TestMethod()]
        public void HasCycleWithOddLenghtTest2()
        {
            var graph = new Graph(6);
            graph.AddNeighbours(0, new List<int>() { 1 });
            graph.AddNeighbours(1, new List<int>() { 2, 5, 0 });
            graph.AddNeighbours(2, new List<int>() { 1 });
            graph.AddNeighbours(3, new List<int>() { 4 });
            graph.AddNeighbours(4, new List<int>() { 3, 5 });
            graph.AddNeighbours(5, new List<int>() { 1, 4 });
            Assert.IsFalse(graph.HasCycleWithOddLenght());
        }

        [TestMethod()]
        public void WayToVerticesTest()
        {
            var graph = new Graph(6);
            graph.AddNeighbours(0, new List<int>() { 1 });
            graph.AddNeighbours(1, new List<int>() { 2, 5, 0 });
            graph.AddNeighbours(2, new List<int>() { 1 });
            graph.AddNeighbours(3, new List<int>() { 4 });
            graph.AddNeighbours(4, new List<int>() { 3, 5 });
            graph.AddNeighbours(5, new List<int>() { 1, 4 });
            var ways = graph.WayToVertices(5);
            Assert.AreEqual(1, ways[4]);
            Assert.AreEqual(1, ways[1]);
            Assert.AreEqual(2, ways[2]);
            Assert.AreEqual(2, ways[3]);
            Assert.AreEqual(2, ways[0]);
        }
    }
}
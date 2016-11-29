using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework3.Tests
{
    [TestClass()]
    public class RobotsTests
    {
        [TestMethod()]
        public void WillBeDestroyedTest()
        {
            var graph = new Graph(6);
            graph.AddNeighbours(0, new List<int>() { 1 });
            graph.AddNeighbours(1, new List<int>() { 2, 5, 0 });
            graph.AddNeighbours(2, new List<int>() { 1 });
            graph.AddNeighbours(3, new List<int>() { 4 });
            graph.AddNeighbours(4, new List<int>() { 3, 5 });
            graph.AddNeighbours(5, new List<int>() { 1, 4 });
            var robots = new Robots(graph, new[] { 1, 4 });
            Assert.IsTrue(robots.WillBeDestroyed());
            var robots2 = new Robots(graph, new[] { 1, 5 });
            Assert.IsFalse(robots2.WillBeDestroyed());
        }

        [TestMethod()]
        public void WillBeDestroyedTest2()
        {
            var graph = new Graph(3);
            graph.AddNeighbours(0, new List<int>() { 1 });
            graph.AddNeighbours(1, new List<int>() { 2 });
            var robots = new Robots(graph, new[] { 1, 2 });
            Assert.IsFalse(robots.WillBeDestroyed());
            var robots2 = new Robots(graph, new[] { 2, 0 });
            Assert.IsTrue(robots2.WillBeDestroyed());
        }

        [TestMethod()]
        public void WillBeDestroyedTest3()
        {
            var graph = new Graph(4);
            graph.AddNeighbours(0, new List<int>() { 1, 3 });
            graph.AddNeighbours(1, new List<int>() { 3 });
            graph.AddNeighbours(2, new List<int>() { 3 });
            var robots = new Robots(graph, new[] { 0, 2 });
            Assert.IsTrue(robots.WillBeDestroyed());
            var robots2 = new Robots(graph, new[] { 2, 0 });
            Assert.IsTrue(robots2.WillBeDestroyed());
        }

        [TestMethod()]
        public void SingleRobotTest()
        {
            var graph = new Graph(3);
            graph.AddNeighbours(0, new List<int>() { 1, 2 });
            graph.AddNeighbours(1, new List<int>() { 2 });
            graph.AddNeighbours(2, new List<int>());
            var robots = new Robots(graph, new[] { 0 });
            Assert.IsFalse(robots.WillBeDestroyed());
        }

        [TestMethod()]
        public void SquareTest()
        {
            var graph = new Graph(4);
            graph.AddNeighbours(0, new List<int>() { 1, 2 });
            graph.AddNeighbours(1, new List<int>() { 3 });
            graph.AddNeighbours(2, new List<int>() { 3 });
            var robots = new Robots(graph, new[] { 0, 1, 2, 3 });
            Assert.IsTrue(robots.WillBeDestroyed());
        }

        [TestMethod()]
        public void SquareTest2()
        {
            var graph = new Graph(4);
            graph.AddNeighbours(0, new List<int>() { 1, 2 });
            graph.AddNeighbours(1, new List<int>() { 3 });
            graph.AddNeighbours(2, new List<int>() { 3 });
            var robots = new Robots(graph, new[] { 0, 1,  3 });
            Assert.IsFalse(robots.WillBeDestroyed());
        }
    }
}
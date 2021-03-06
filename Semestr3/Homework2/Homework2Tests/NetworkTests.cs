﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Homework2.Tests
{
    [TestClass()]
    public class NetworkTests
    {
        [TestMethod()]
        public void StartNetworkTest()
        {
            var windows = new OS(0.5);
            var linux = new OS(0.9);
            var mac = new OS(0.3);
            var computers = new List<Computer>
            {
                new Computer(windows, false, new List<int> {1, 2}),
                new Computer(linux, false, new List<int> {0, 2}),
                new Computer(mac, true, new List<int> {0, 1})
            };
            var network = new Network(computers);
            network.StartNetwork();
            //Network finished. All computers are infectioned
        }

        [TestMethod()]
        public void StartNetworkTest2()
        {
            var bestOsEver = new OS(0.01);
            var computers = new List<Computer>
            {
                new Computer(bestOsEver, false, new List<int> {1, 2, 3}),
                new Computer(bestOsEver, false, new List<int> {0, 2}),
                new Computer(bestOsEver, true, new List<int> {0, 1, 3}),
                new Computer(bestOsEver, false, new List<int> {0, 3})
            };
            var network = new Network(computers);
            network.StartNetwork();
            //Network finished. All computers are infectioned
        }

        [TestMethod()]
        public void StartNetworkTest3()
        {
            var virusOs = new OS(0.99);
            var pro = new OS(0.100500);
            var русскаяОсь = new OS(0.005);
            var computers = new List<Computer>
            {
                new Computer(pro, true, new List<int> {5}),
                new Computer(virusOs, false, new List<int> {5}),
                new Computer(virusOs, false, new List<int> {5}),
                new Computer(pro, false, new List<int> {5}),
                new Computer(virusOs, true, new List<int> {5}),
                new Computer(русскаяОсь, false, new List<int> {0, 1, 2, 3, 4})
            };
            var network = new Network(computers);
            network.StartNetwork();
            //Network finished. All computers are infectioned
        }

        [TestMethod()]
        public void StartNetworkTest4()
        {
            var virusOs = new OS(0.99);
            var pro = new OS(0.100500);
            var русскаяОсь = new OS(0.005);
            var computers = new List<Computer>
            {
                new Computer(pro, false, new List<int> {5}),
                new Computer(virusOs, false, new List<int> {5}),
                new Computer(virusOs, false, new List<int> {5}),
                new Computer(pro, false, new List<int> {5}),
                new Computer(virusOs, false, new List<int> {5}),
                new Computer(русскаяОсь, false, new List<int> {0, 1, 2, 3, 4})
            };
            var network = new Network(computers);
            network.StartNetwork();
            //Network finished. There are no viruses in the system
        }

        [TestMethod()]
        public void TestForNeighboursInfections()
        {
            var windows = new OS(1);
            var linux = new OS(1);
            var mac = new OS(1);
            var computers = new List<Computer>
            {
                new Computer(windows, true, new List<int> {1}),
                new Computer(linux, false, new List<int> {0, 2}),
                new Computer(mac, false, new List<int> {1})
            };
            var network = new Network(computers);
            Assert.IsTrue(network.Computers[0].Infected);
            Assert.IsFalse(network.Computers[1].Infected);
            Assert.IsFalse(network.Computers[2].Infected);
            network.Infections();
            Assert.IsTrue(network.Computers[0].Infected);
            Assert.IsTrue(network.Computers[1].Infected);
            Assert.IsFalse(network.Computers[2].Infected);

        }

        [TestMethod()]
        public void TestForNotInfectedSystem()
        {
            var windows = new OS(1);
            var linux = new OS(1);
            var mac = new OS(1);
            var computers = new List<Computer>
            {
                new Computer(windows, false, new List<int> {1}),
                new Computer(linux, false, new List<int> {0, 2}),
                new Computer(mac, false, new List<int> {1})
            };
            var network = new Network(computers);
            Assert.IsFalse(network.Computers[0].Infected);
            Assert.IsFalse(network.Computers[1].Infected);
            Assert.IsFalse(network.Computers[2].Infected);
            network.Infections();
            Assert.IsFalse(network.Computers[0].Infected);
            Assert.IsFalse(network.Computers[1].Infected);
            Assert.IsFalse(network.Computers[2].Infected);
        }
    }
}
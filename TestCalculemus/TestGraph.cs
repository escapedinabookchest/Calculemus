using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculemus.Model;
using System.Collections.Generic;

namespace TestCalculemus
{
    [TestClass]
    public class TestGraph
    {
        private Parser parser;
        private Graph graph;

        [TestInitialize]
        public void initialize()
        {
            parser = new Parser();
            graph = new Graph(new TopologicalSorting());
            parser.Parse(@"C:\Users\Hersenspinsel\Documents\GitHub\Calculemus\Calculemus\circuit.txt");
            graph.AddVertices(parser.Vertices);
            graph.AddEdges(parser.Edges);
        }

        [TestMethod]
        public void TestAddVertices()
        {
            graph.Sort();

            foreach (string vertex in graph.SortedVertices)
            {
                Console.WriteLine(vertex);
            }
        }

        [TestMethod]
        public void TestCalculate()
        {
            graph.Sort();
            graph.Calculate();
        }
    }
}

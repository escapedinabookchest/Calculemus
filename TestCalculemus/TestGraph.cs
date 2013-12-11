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
            graph = new Graph();
        }

        [TestMethod]
        public void TestAddVertices()
        {
            parser.Parse(@"C:\Users\Hersenspinsel\Documents\GitHub\Calculemus\Calculemus\circuit.txt");
            graph.AddVertices(parser.Vertices);
            graph.AddEdges(parser.Edges);
            
            foreach (KeyValuePair<string, Node> vertex in graph.Vertices)
            {
                //Console.WriteLine(vertex.Key + ": " + vertex.Value);
            }

            graph.createAdjacencyList();
            graph.topo();
        }
    }
}

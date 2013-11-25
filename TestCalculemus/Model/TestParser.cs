using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculemus.Model;
using System.Collections.Generic;

namespace TestCalculemus
{
    [TestClass]
    public class TestParser
    {
        private Parser parser;

        [TestInitialize]
        public void TestInitialize()
        {
            parser = new Parser();
        }

        [TestMethod]
        public void TestParse()
        {
            parser.Parse(@"C:\Users\Hersenspinsel\Documents\GitHub\Calculemus\Calculemus\circuit.txt");

            Console.WriteLine("Vertices:");
            foreach (KeyValuePair<string, string> pair in parser.Vertices)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }

            Console.WriteLine("Edges:");
            foreach (KeyValuePair<string, LinkedList<string>> pair in parser.Edges)
            {
                Console.Write(pair.Key + ": ");

                foreach (string value in pair.Value)
                {
                    Console.Write(value + ",");
                }

                Console.WriteLine();
            }
        }

        //[TestMethod]
        //public void TestAddVertex()
        //{
        //    Dictionary<string, string> vertices = new Dictionary<string, string>();
        //    vertices.Add("NODE1", "AND");

        //    parser.AddVertex("NODE1:AND;");

        //    CollectionAssert.AreEqual(vertices, parser.Vertices);
        //}

        //[TestMethod]
        //public void TestAddEdge()
        //{
        //    Dictionary<string, LinkedList<string>> edges = new Dictionary<string, LinkedList<string>>();

        //    LinkedList<string> values = new LinkedList<string>();
        //    values.AddFirst("NODE1");
        //    values.AddFirst("NODE2");
        //    values.AddFirst("NODE3");
        //    edges.Add("A", values);

        //    parser.AddEdge("!A:NODE1,NODE2,NODE3;");

        //    foreach (KeyValuePair<string, LinkedList<string>> pair in parser.Edges)
        //    {
        //        Console.WriteLine(pair.Key);

        //        foreach(string value in pair.Value)
        //        {
        //            Console.WriteLine(value);
        //        }
        //    }

        //    CollectionAssert.AreEqual(edges, parser.Edges);
        //}

        //[TestMethod]
        //public void TestIsVertex()
        //{
        //    Assert.IsTrue(parser.IsVertex("*A:INPUT_HIGH;"));
        //}

        //[TestMethod]
        //public void TestIsEdge()
        //{
        //    Assert.IsTrue(parser.IsEdge("!A:NODE1,NODE2,NODE3;"));
        //}

        //[TestMethod]
        //public void TestIsComment()
        //{
        //    Assert.IsTrue(parser.IsComment("# This is a comment."));
        //}
    }
}
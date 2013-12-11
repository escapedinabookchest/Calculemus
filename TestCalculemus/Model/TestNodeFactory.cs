using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculemus.Model;

namespace TestCalculemus.Model
{
    /// <summary>
    /// Summary description for TestNodeFactory
    /// </summary>
    [TestClass]
    public class TestNodeFactory
    {
        [TestMethod]
        public void TestGetInstance()
        {
            Node node = Node.create("NOT");
            node.Input = new bool[] { true };
            node.Calculate();
            Console.WriteLine(node.Output);
        }
    }
}

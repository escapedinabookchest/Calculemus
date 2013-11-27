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
            Node input = NodeFactory.GetInstance("INPUT");
            Assert.IsInstanceOfType(input, typeof(InputNode));

            Node probe = NodeFactory.GetInstance("PROBE");
            Assert.IsInstanceOfType(probe, typeof(ProbeNode));

            Node and = NodeFactory.GetInstance("AND");
            Assert.IsInstanceOfType(and, typeof(ComponentNode));

            Node or = NodeFactory.GetInstance("OR");
            Assert.IsInstanceOfType(or, typeof(ComponentNode));

            Node nor = NodeFactory.GetInstance("NOR");
            Assert.IsInstanceOfType(nor, typeof(ComponentNode));

            Node nand = NodeFactory.GetInstance("NAND");
            Assert.IsInstanceOfType(nand, typeof(ComponentNode));

            Node xor = NodeFactory.GetInstance("XOR");
            Assert.IsInstanceOfType(xor, typeof(ComponentNode));
        }
    }
}

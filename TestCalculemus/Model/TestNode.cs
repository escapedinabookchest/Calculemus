using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculemus.Model;

namespace TestCalculemus
{
    [TestClass]
    public class TestNode
    {
        [TestMethod]
        public void TestNot()
        {
            Node node = new Not();

            node.Input = new bool[1] { false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[1] { true };
            Assert.IsFalse(node.Calculate());
        }

        [TestMethod]
        public void TestAnd()
        {
            Node node = new And();

            node.Input = new bool[2] { false, false };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { false, true };
            Assert.IsFalse(node.Calculate());
            
            node.Input = new bool[2] { true, false };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { true, true };
            Assert.IsTrue(node.Calculate());
        }

        [TestMethod]
        public void TestOr()
        {
            Node node = new Or();

            node.Input = new bool[2] { false, false };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { false, true };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, true };
            Assert.IsTrue(node.Calculate());
        }

        [TestMethod]
        public void TestNor()
        {
            Node node = new Nor();

            node.Input = new bool[2] { false, false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { false, true };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { true, false };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { true, true };
            Assert.IsFalse(node.Calculate());
        }

        [TestMethod]
        public void TestNand()
        {
            Node node = new Nand();

            node.Input = new bool[2] { false, false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { false, true };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, true };
            Assert.IsFalse(node.Calculate());
        }
        
        [TestMethod]
        public void TestXor()
        {
            Node node = new Xor();

            node.Input = new bool[2] { false, false };
            Assert.IsFalse(node.Calculate());

            node.Input = new bool[2] { false, true };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, false };
            Assert.IsTrue(node.Calculate());

            node.Input = new bool[2] { true, true };
            Assert.IsFalse(node.Calculate());
        }
    }
}
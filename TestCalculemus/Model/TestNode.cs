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

            node.AddInput(false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true);
            Assert.IsFalse(node.Calculate());
        }

        [TestMethod]
        public void TestAnd()
        {
            Node node = new And();

            node.AddInput(false, false);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(false, true);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();
            
            node.AddInput(true, false);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, true);
            Assert.IsTrue(node.Calculate());
        }

        [TestMethod]
        public void TestOr()
        {
            Node node = new Or();

            node.AddInput(false, false);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(false, true);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, true);
            Assert.IsTrue(node.Calculate());
        }

        [TestMethod]
        public void TestNor()
        {
            Node node = new Nor();

            node.AddInput(false, false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(false, true);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, false);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, true);
            Assert.IsFalse(node.Calculate());
        }

        [TestMethod]
        public void TestNand()
        {
            Node node = new Nand();

            node.AddInput(false, false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(false, true);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, true);
            Assert.IsFalse(node.Calculate());
        }
        
        [TestMethod]
        public void TestXor()
        {
            Node node = new Xor();

            node.AddInput(false, false);
            Assert.IsFalse(node.Calculate());
            node.Input.Clear();

            node.AddInput(false, true);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, false);
            Assert.IsTrue(node.Calculate());
            node.Input.Clear();

            node.AddInput(true, true);
            Assert.IsFalse(node.Calculate());
        }
    }
}
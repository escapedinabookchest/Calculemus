using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    internal class NodeFactory
    {
        public static Node GetInstance(string node)
        {
            switch (node)
            {
                case "INPUT":
                    return new InputNode();
                case "PROBE":
                    return new ProbeNode();
                case "AND":
                    return new ComponentNode(new And());
                case "OR":
                    return new ComponentNode(new Or());
                case "NOR":
                    return new ComponentNode(new Nor());
                case "NAND":
                    return new ComponentNode(new Nand());
                case "XOR":
                    return new ComponentNode(new Xor());
                default:
                    return null;
            }
        }
    }
}

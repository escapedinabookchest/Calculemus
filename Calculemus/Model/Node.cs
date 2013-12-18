using System;
using System.Collections;
using System.Collections.Generic;
namespace Calculemus.Model
{
    public abstract class Node : ICloneable, IGetKey<String>
    {
        private List<bool> input;
        private bool output;

        protected Node() 
        {
            input = new List<bool>();
        }

        public static Node create(string node)
        {
            return NodeFactory<string, Node>.create(node);
        }

        public List<bool> Input
        {
            get { return this.input; }
            set { this.input = value; }
        }

        public bool Output
        {
            get { return this.output; }
            protected set { this.output = value; }
        }

        public void AddInput(params bool[] input)
        {
            foreach (bool b in input)
            {
                Input.Add(b);
            }
        }

        public abstract string getKey();
        public abstract object Clone();
        public abstract bool Calculate();
    }

    internal class LowInputNode : Node, OneInput
    {
        public override bool Calculate()
        {
            return Output = false; //Input[0];
        }

        public override string getKey()
        {
            return "INPUT_LOW";
        }

        public override object Clone()
        {
            return new LowInputNode();
        }
    }

    internal class HighInputNode : Node, OneInput
    {
        public override bool Calculate()
        {
            return Output = true; //Input[0];
        }

        public override string getKey()
        {
            return "INPUT_HIGH";
        }

        public override object Clone()
        {
            return new HighInputNode();
        }
    }

    internal class ProbeNode : Node, OneInput
    {
        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            return Output = input[0];
        }

        public override string getKey()
        {
            return "PROBE";
        }

        public override object Clone()
        {
            return new ProbeNode();
        }
    }

    internal class Not : Node, OneInput
    {
        public override string getKey()
        {
            return "NOT";
        }

        public override object Clone()
        {
            return new Not();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if (input[0])
            {
                
                return Output = false;
            }

            return Output = true;
        }
    }

    internal class And : Node, TwoInputs
    {
        public override string getKey()
        {
            return "AND";
        }

        public override object Clone()
        {
            return new And();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if (input[0] && input[1])
                return Output = true;

            return Output = false;
        }
    }

    internal class Or : Node, TwoInputs
    {
        public override string getKey()
        {
            return "OR";
        }

        public override object Clone()
        {
            return new Or();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if (input[0] || input[1])
                return Output = true;

            return Output = false;
        }
    }

    internal class Nor : Node, TwoInputs
    {
        public override string getKey()
        {
            return "NOR";
        }

        public override object Clone()
        {
            return new Nor();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if (!(input[0] || input[1]))
                return Output = true;

            return Output = false;
        }
    }

    internal class Nand : Node, TwoInputs
    {
        public override string getKey()
        {
            return "NAND";
        }

        public override object Clone()
        {
            return new Nand();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if (!(input[0] && input[1]))
                return Output = true;

            return Output = false;
        }
    }

    internal class Xor : Node, TwoInputs
    {
        public override string getKey()
        {
            return "XOR";
        }

        public override object Clone()
        {
            return new Xor();
        }

        public override bool Calculate()
        {
            bool[] input = Input.ToArray();

            if ((input[0] || input[1]) && !(input[0] && input[1]))
                return Output = true;

            return Output = false;
        }
    }
}
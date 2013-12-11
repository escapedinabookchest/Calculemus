using System;
namespace Calculemus.Model
{
    internal abstract class Node : ICloneable, IGetKey<String>
    {
        private bool[] input;
        private bool output;

        protected Node() { }

        public static Node create(string node)
        {
            return NodeFactory<string, Node>.create(node);
        }

        public bool[] Input
        {
            get { return this.input; }
            set { this.input = value; }
        }

        public bool Output
        {
            get { return this.output; }
            protected set { this.output = value; }
        }

        public abstract string getKey();
        public abstract object Clone();
        public abstract bool Calculate();
    }

    internal class LowInputNode : Node, OneInput
    {
        public override bool Calculate()
        {
            return Output = Input[0];
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
            return Output = Input[0];
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
            if (Input.Length != 1)
                throw new ArgumentOutOfRangeException();

            return Output = Input[0];
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
            if (Input[0])
                return Output = false;
            else
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
            if (Input[0] && Input[1])
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
            if (Input[0] || Input[1])
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
            if (!(Input[0] || Input[1]))
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
            if (!(Input[0] && Input[1]))
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
            if ((Input[0] || Input[1]) && !(Input[0] && Input[1]))
                return Output = true;

            return Output = false;
        }
    }
}
using System;

namespace Calculemus.Model
{
    /**
     * The class Component uses a strategy pattern with the interface IComponentLogic 
     * to assign one logical operator to itself.
     */
    internal class Component : Node
    {
        private IComponentLogic componentLogic;
        private bool[] input;
        private bool output;

        public Component(IComponentLogic componentLogic)
        {
            this.componentLogic = componentLogic;
        }

        public bool[] Input
        {
            get { return this.input; }
            set { input = value; }
        }

        public bool Output
        {
            get { return this.output; }
            set { this.output = value; }
        }

        /**
         * The method Calculate checks if the correct number of propositions are passed 
         * to the logical operator and returns its result.
         */
        public bool Calculate()
        {
            if (componentLogic is OneInput && Input.Length != 1)
                throw new ArgumentOutOfRangeException();

            if (componentLogic is TwoInputs && Input.Length != 2)
                throw new ArgumentOutOfRangeException();

            if (componentLogic is ThreeInputs && Input.Length != 3)
                throw new ArgumentOutOfRangeException();

            return Output = componentLogic.Calculate(input);
        }
    }

    internal class Not : OneInput
    {
        public bool Calculate(bool[] input)
        {
            if (input[0])
                return false;
            else
                return true;
        }
    }

    internal class And : TwoInputs
    {
        public bool Calculate(bool[] input)
        {
            if (input[0] && input[1])
                return true;

            return false;
        }
    }

    internal class Or : TwoInputs
    {
        public bool Calculate(bool[] input)
        {
            if (input[0] || input[1])
                return true;

            return false;
        }
    }

    internal class Nor : TwoInputs
    {
        public bool Calculate(bool[] input)
        {
            if (!(input[0] || input[1]))
                return true;

            return false;
        }
    }

    internal class Nand : TwoInputs
    {
        public bool Calculate(bool[] input)
        {
            if (!(input[0] && input[1]))
                return true;

            return false;
        }
    }

    internal class Xor : TwoInputs
    {
        public bool Calculate(bool[] input)
        {
            if ((input[0] || input[1]) && !(input[0] && input[1]))
                return true;

            return false;
        }
    }
}
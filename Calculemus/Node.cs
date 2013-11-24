using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus
{
    internal abstract class Node
    {
        protected bool wasVisited;
    }

    internal class Input : Node
    {
        private bool output;

        public Input(InputValue input) 
        {
            switch (input)
            {
                case InputValue.INPUT_LOW:
                    this.output = false;
                    break;
                case InputValue.INPUT_HIGH:
                    this.output = true;
                    break;
            }
        }

        public bool Output
        {
            get { return this.output; }
            set { output = value; }
        }
    }

    internal enum InputValue
    {
        INPUT_LOW = 0, INPUT_HIGH = 1
    }

    internal class Probe : Node
    {
        private bool result;

        public Probe(bool result)
        {
            this.result = result;
        }

        public bool Result
        {
            get { return this.result; }
            set { this.result = value; }
        }
    }

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

    internal interface IComponentLogic
    {
        bool Calculate(bool[] input);
    }

    internal interface OneInput : IComponentLogic {}
    internal interface TwoInputs : IComponentLogic {}
    internal interface ThreeInputs : IComponentLogic { }

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
}
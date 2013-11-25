namespace Calculemus.Model
{
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
}

namespace Calculemus.Model
{
    internal abstract class Node
    {
        private bool[] input;
        private bool output;

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

        public abstract bool Calculate();
    }
}
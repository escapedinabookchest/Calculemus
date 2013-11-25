namespace Calculemus.Model
{
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
}
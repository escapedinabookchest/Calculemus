using System;

namespace Calculemus.Model
{
    internal class ProbeNode : Node
    {
        public override bool Calculate()
        {
            if (Input.Length != 1)
                throw new ArgumentOutOfRangeException();

            return Output = Input[0];
        }
    }
}
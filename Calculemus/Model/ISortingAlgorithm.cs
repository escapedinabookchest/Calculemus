using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    public interface ISortingAlgorithm
    {
        string this[int i] { get; }
        void Sort(IGraph graph);
        IEnumerator<string> GetEnumerator();
    }
}
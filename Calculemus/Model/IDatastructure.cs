using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    public interface IDatastructure
    {
        Dictionary<string, Node> Vertices { get; set; }
        Dictionary<string, LinkedList<string>> Edges { get; set; }
        Dictionary<string, bool> Result { get; set; }

        void AddVertices(Dictionary<string, string> input);
        void AddEdges(Dictionary<string, LinkedList<string>> input);
        void Calculate();
        void Sort();
    }

    public interface IGraph : IDatastructure {}
}

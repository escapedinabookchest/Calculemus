using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    public interface IGraph
    {
        Dictionary<string, Node> Vertices { get; set; }
        Dictionary<string, LinkedList<string>> Edges { get; set; }
        string[] SortedVertices { get; set; }

        void AddVertices(Dictionary<string, string> input);
        void AddEdges(Dictionary<string, LinkedList<string>> input);
        void Sort();
    }
}

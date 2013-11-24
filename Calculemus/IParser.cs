using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus
{
    public interface IParser
    {
        Dictionary<string, string> Vertices { get; set; }
        Dictionary<string, LinkedList<string>> Edges { get; set; }
        void Parse(string filename);
    }
}
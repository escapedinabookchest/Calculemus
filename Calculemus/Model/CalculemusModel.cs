using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    public class CalculemusModel
    {
        IParser parser;
        IDatastructure datastructure;

        public CalculemusModel(IParser parser, IDatastructure datastructure)
        {
            this.parser = parser;
            this.datastructure = datastructure;
        }

        public Dictionary<string, bool> Result
        {
            get { return datastructure.Result; }
        }

        public void Parse(String filename)
        {
            parser.Parse(filename);
            datastructure.AddVertices(parser.Vertices);
            datastructure.AddEdges(parser.Edges);
        }

        public void Sort()
        {
            datastructure.Sort();
        }

        public void Calculate()
        {
            datastructure.Calculate();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    /**
     * 
     */
    internal class Graph : IGraph
    {
        private ISortingAlgorithm algorithm;
        private Dictionary<string, Node> vertices;
        private Dictionary<string, LinkedList<string>> edges;
        private Dictionary<string, bool> result;

        public Graph(ISortingAlgorithm algorithm) // Strategy pattern
        {
            this.algorithm = algorithm;
            vertices = new Dictionary<string, Node>();
            edges = new Dictionary<string, LinkedList<string>>();
            result = new Dictionary<string, bool>();
        }

        public Dictionary<string, Node> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }

        public Dictionary<string, LinkedList<string>> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        public Dictionary<string, bool> Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Sort()
        {
            algorithm.Sort(this);
        }

        public void Calculate()
        {
            foreach (string vertex in algorithm)
            {
                Node current = Vertices.ContainsKey(vertex) ? Vertices[vertex] : null;
                LinkedList<string> edges = Edges.ContainsKey(vertex) ? Edges[vertex] : null;

                current.Calculate();

                if (current is ProbeNode)
                {
                    Console.WriteLine(vertex + ": " + current.Output);
                    result.Add(vertex, current.Output);
                    continue;
                }

                Console.Write(vertex + " (" + current.Output + "): ");
                foreach (string edge in edges)
                {
                    Console.Write(edge + " ");
                    Vertices[edge].AddInput(current.Output);
                }

                Console.WriteLine();
            }
        }

        public void AddVertices(Dictionary<string, string> input)
        {
            foreach (KeyValuePair<string, string> vertex in input)
            {
                Vertices.Add(vertex.Key, Node.create(vertex.Value));
            }
        }

        public void AddEdges(Dictionary<string, LinkedList<string>> input)
        {
            Edges = input;
        }
    }
}
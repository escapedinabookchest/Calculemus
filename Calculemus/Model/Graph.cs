using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    internal class Graph : IGraph
    {
        private ISortingAlgorithm algorithm;
        private Dictionary<string, Node> vertices;
        private Dictionary<string, LinkedList<string>> edges;
        private string[] sortedVertices;

        public Graph(ISortingAlgorithm algorithm)
        {
            this.algorithm = algorithm;
            vertices = new Dictionary<string, Node>();
            edges = new Dictionary<string, LinkedList<string>>();
            sortedVertices = null;
        }

        public void Calculate()
        {
            foreach (string vertex in SortedVertices)
            {
                Node current = Vertices.ContainsKey(vertex) ? Vertices[vertex] : null;
                LinkedList<string> edges = Edges.ContainsKey(vertex) ? Edges[vertex] : null;

                if (current is ProbeNode)
                {
                    continue;
                }

                current.Calculate();
                
                Console.Write(vertex + ": ");
                foreach (string edge in edges)
                {
                    Console.Write(edge + " ");
                    Vertices[edge].AddInput(current.Output);
                }

                Console.WriteLine();
            }
        }

        public Dictionary<string, Node> Vertices
        {
            get { return this.vertices; }
            set { this.vertices = value; }
        }

        public Dictionary<string, LinkedList<string>> Edges
        {
            get { return this.edges; }
            set { this.edges = value; }
        }

        public string[] SortedVertices
        {
            get { return sortedVertices; }
            set { sortedVertices = value; }
        }

        public void Sort()
        {
            sortedVertices = algorithm.Sort(this);
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
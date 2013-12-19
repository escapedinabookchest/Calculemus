using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    /**
     * The class Topological Sorting is responsible for taking the vertices and edges from a graph, 
     * sorting it, and return the result through an indexer.
     */ 
    public class TopologicalSorting : ISortingAlgorithm, IEnumerable<string>
    {
        private List<string> sorted;

        public TopologicalSorting()
        {
            sorted = new List<string>();
        }

        public string this[int i]
        {
            get { return sorted[i]; }
        }

        public void Sort(IGraph graph)
        {
            Algorithm algorihm = new Algorithm(graph);

            for (int i = 0; i < algorihm.SortedArray.Length; i++)
            {
                sorted.Add(algorihm.SortedArray[i]);
            }
        }
        
        public IEnumerator<string> GetEnumerator() 
        {
            return sorted.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /**
         * The class Algorithm is the actual topological sorting algorithm but separated for clarity.
         */ 
        private class Algorithm
        {
            private IGraph graph;
            private string[] vertexList;
            private string[] sortedArray;
            private int numberOfVertices;
            private int[,] adjacencyMatrix;

            public Algorithm(IGraph graph)
            {
                this.graph = graph;
                vertexList = new string[graph.Vertices.Count];

                sortedArray = new string[graph.Vertices.Count];
                numberOfVertices = graph.Vertices.Count;
                adjacencyMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];

                CreateAdjacencyList();
                Sort();
            }

            public string[] SortedArray
            {
                get { return sortedArray; }
                set { sortedArray = value; }
            }
            
            private void CreateAdjacencyList()
            {
                Dictionary<string, int> d = new Dictionary<string, int>();
                int i = 0;

                foreach (KeyValuePair<string, Node> vertex in graph.Vertices)
                {
                    d.Add(vertex.Key, i);
                    vertexList[i] = vertex.Key;
                    i++;
                }

                foreach (KeyValuePair<string, LinkedList<string>> edge in graph.Edges)
                {
                    int n = d[edge.Key];

                    foreach (string e in edge.Value)
                    {
                        int p = d[e];
                        adjacencyMatrix[n, p] = 1;
                    }
                }

            }

            private void Sort()
            {
                int orig_nVerts = numberOfVertices;
                while (numberOfVertices > 0)
                {
                    int currentVertex = noSuccessors();

                    if (currentVertex == -1) //  check for cycles
                    {
                        Console.WriteLine("Graph has cycles");
                        return;
                    }

                    sortedArray[numberOfVertices - 1] = vertexList[currentVertex];
                    deleteVertex(currentVertex);
                }
            }

            private int noSuccessors()
            {
                bool isEdge; // edge from row to column in adjMat
                for (int row = 0; row < numberOfVertices; row++)
                {
                    isEdge = false;

                    for (int col = 0; col < numberOfVertices; col++)
                    {
                        if (adjacencyMatrix[row, col] > 0)
                        {
                            isEdge = true;
                            break;
                        }
                    }

                    if (!isEdge)
                        return row;
                }
                return -1; // no such vertex
            }

            private void deleteVertex(int vertex)
            {
                if (vertex != numberOfVertices - 1) // if not last vertex,
                { // delete from vertexList
                    for (int j = vertex; j < numberOfVertices - 1; j++)
                        vertexList[j] = vertexList[j + 1];
                    // delete row from adjMat
                    for (int row = vertex; row < numberOfVertices - 1; row++)
                        moveRowUp(row, numberOfVertices);
                    // delete col from adjMat
                    for (int col = vertex; col < numberOfVertices - 1; col++)
                        moveColLeft(col, numberOfVertices - 1);
                }
                numberOfVertices--;
            }

            private void moveRowUp(int row, int length)
            {
                for (int col = 0; col < length; col++)
                    adjacencyMatrix[row, col] = adjacencyMatrix[row + 1, col];
            }

            private void moveColLeft(int col, int length)
            {
                for (int row = 0; row < length; row++)
                    adjacencyMatrix[row, col] = adjacencyMatrix[row, col + 1];
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    public class TopologicalSorting : ISortingAlgorithm
    {
        private IGraph graph;
        private string[] vertexList;
        private string[] sortedArray;
        private int numberOfVertices;
        private int[,] adjacencyMatrix;

        public TopologicalSorting() {}

        public string[] Sort(IGraph graph)
        {
            this.graph = graph;
            vertexList = new string[graph.Vertices.Count];
            sortedArray = new string[graph.Vertices.Count];
            numberOfVertices = graph.Vertices.Count;
            adjacencyMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];

            CreateAdjacencyList();
            Algortithm();
            return sortedArray;
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

        private void Algortithm()
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
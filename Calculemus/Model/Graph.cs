using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculemus.Model
{
    internal class Graph : IGraph
    {
        private Dictionary<string, Node> vertices;
        private Dictionary<string, LinkedList<string>> edges;

        private string[] vertexList;
        private string[] sortedArray;
        private int numberOfVertices;
        private int[,] adjacencyMatrix;

        public Graph()
        {
            vertices = new Dictionary<string, Node>();
            edges = new Dictionary<string, LinkedList<string>>();

            //vertexList = new string[Vertices.Count];
            //sortedArray = new string[Vertices.Count];
            //numberOfVertices = Edges.Count;
            //adjacencyMatrix = new int[Edges.Count, Edges.Count];
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

        public void createAdjacencyList()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            int i = 0;

            foreach (KeyValuePair<string, Node> vertex in Vertices)
            {
                d.Add(vertex.Key, i);
                i++;
            }

            adjacencyMatrix = new int[i, i];
            numberOfVertices = i;

            foreach (KeyValuePair<string, LinkedList<string>> edge in Edges)
            {
                int n = d[edge.Key];

                foreach (string e in edge.Value)
                {
                    int p = d[e];
                    adjacencyMatrix[n, p] = 1;
                }
            }

            for (int z = 0; z < adjacencyMatrix.GetLength(0); z++)
            {
                for (int x = 0; x < adjacencyMatrix.GetLength(1); x++)
                {
                    Console.Write(adjacencyMatrix[z, x] + " ");
                }

                Console.WriteLine();
            }
        }

        public void topo() // topological sort
        {
            int orig_nVerts = numberOfVertices; // remember how many verts
            while (numberOfVertices > 0) // while vertices remain,
            {
                // get a vertex with no successors, or -1
                int currentVertex = noSuccessors();
                if (currentVertex == -1) // must be a cycle
                {
                    Console.WriteLine("ERROR: Graph has cycles");
                    return;
                }
                // insert vertex label in sorted array (start at end)
                sortedArray[numberOfVertices - 1] = vertexList[currentVertex];
                deleteVertex(currentVertex); // delete vertex
            } // end while
            // vertices all gone; display sortedArray
            Console.WriteLine("Topologically sorted order: ");
            for (int j = 0; j < orig_nVerts; j++)
                Console.WriteLine(sortedArray[j]);
            Console.WriteLine("");
        } // end topo

        public int noSuccessors() // returns vert with no successors
        { // (or -1 if no such verts)
            bool isEdge; // edge from row to column in adjMat
            for (int row = 0; row < numberOfVertices; row++) // for each vertex,
            {
                isEdge = false; // check edges
                for (int col = 0; col < numberOfVertices; col++)
                {
                    if (adjacencyMatrix[row, col] > 0) // if edge to
                    { // another,
                        isEdge = true;
                        break; // this vertex
                    } // has a successor
                } // try another
                if (!isEdge) // if no edges,
                    return row; // has no successors
            }
            return -1; // no such vertex
        } // end noSuccessors()

        public void deleteVertex(int delVert)
        {
            if (delVert != numberOfVertices - 1) // if not last vertex,
            { // delete from vertexList
                for (int j = delVert; j < numberOfVertices - 1; j++)
                    vertexList[j] = vertexList[j + 1];
                // delete row from adjMat
                for (int row = delVert; row < numberOfVertices - 1; row++)
                    moveRowUp(row, numberOfVertices);
                // delete col from adjMat
                for (int col = delVert; col < numberOfVertices - 1; col++)
                    moveColLeft(col, numberOfVertices - 1);
            }
            numberOfVertices--; // one less vertex
        } // end deleteVertex

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
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculemus.Model
{
    /**
     * The class Parser parses the textfile and puts its vertices and edges in the appointed dictionaries. 
     */
    public class Parser : IParser {
        private Dictionary<string, string> vertices;
        private Dictionary<string, LinkedList<string>> edges;

        public Parser()
        {
            vertices = new Dictionary<string, string>();
            edges = new Dictionary<string, LinkedList<string>>();
        }

        public Dictionary<string, string> Vertices
        {
            get { return this.vertices; }
            set { this.vertices = value; }
        }

        public Dictionary<string, LinkedList<string>> Edges
        {
            get { return this.edges; }
            set { this.edges = value; }
        }

        public void Parse(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                int errors = 0;

                foreach (string line in lines)
                {
                    errors = ParseLine(line) ? errors : errors++;
                }

                if (errors > 0)
                    Console.WriteLine("There are {0} syntax errors in file {1}!", errors, filename);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Boolean ParseLine(string line)
        {
            if (IsVertex(line))
            {
                AddVertex(line);
                return true;
            }

            if (IsEdge(line))
            {
                AddEdge(line);
                return true;
            }

            if (IsComment(line))
            {
                return true;
            }

            return false;
        }

        private void AddVertex(string line)
        {
            StringBuilder sb = new StringBuilder();
            string key = "";
            string value = "";

            foreach (char c in line)
            {
                switch (c)
                {
                    case '*':
                        break;

                    case ';':
                        value = sb.ToString();
                        sb.Clear();
                        break;

                    case ':':
                        key = sb.ToString();
                        sb.Clear();
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            }

            Vertices.Add(key, value);
        }

        private void AddEdge(string line)
        {
            StringBuilder sb = new StringBuilder();
            string key = "";
            LinkedList<string> values = new LinkedList<string>();

            foreach (char c in line)
            {
                switch (c)
                {
                    case '!':
                        break;

                    case ';':
                        values.AddFirst(sb.ToString());
                        sb.Clear();
                        break;

                    case ',':
                        values.AddFirst(sb.ToString());
                        sb.Clear();
                        break;

                    case ':':
                        key = sb.ToString();
                        sb.Clear();
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            }

            Edges.Add(key, values);
        }

        private Boolean IsVertex(string line)
        {
            Match match = Regex.Match(line, @"^[*][A-Z]{1,8}([0-9]{1,4})?[:][A-Z_]{1,20}[;]$");

            if (match.Success)
                return true;

            return false;
        }

        private Boolean IsEdge(string line)
        {
            Match match = Regex.Match(line, @"^[!][A-Z]{1,8}([0-9]{1,4})?[:]([A-Z]{1,8}([0-9]{1,4})?[,]?)*[;]$");

            if (match.Success)
                return true;

            return false;
        }

        private Boolean IsComment(string line)
        {
            Match match = Regex.Match(line, @"^#");

            if (match.Success)
                return true;

            return false;
        }
    }
}
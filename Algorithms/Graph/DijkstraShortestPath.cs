using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph2
{
    public class Graph
    {
        private int last_index = 0;
        public Vertex[] Vertices;

        public Graph(string[] names)
        {
            Vertices = new Vertex[names.Length];
            foreach (string name in names)
            {
                this.Vertices[last_index] = new Vertex();
                this.Vertices[last_index].Name = name;
                last_index++;
            }
        }
        public void AddEdges(int vertexIndex, int[] targets)
        {
            this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                this.Vertices[vertexIndex].VertexLinks[i] =
                  new Edge(this.Vertices[vertexIndex], this.Vertices[targets[i]]);
            }
        }
        public void AddEdges(int vertexIndex, int[] targets, double[] weights)
        {
            this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                this.Vertices[vertexIndex].VertexLinks[i] =
                  new Edge(this.Vertices[vertexIndex], this.Vertices[targets[i]], weights[i]);
            }
        }


        public void Dijkstra()
        {
            Console.WriteLine("Dijkstra From Graph Class;");
            for (int i = 1; i < this.Vertices.Length; i++)
            {
                this.Vertices[i].TotalLength = double.MaxValue;
            }

            Vertex current_vertex;
            for (int i = 0; i < this.Vertices.Length; i++)
            {
                current_vertex = this.Vertices[i];
                Edge[] destinations = current_vertex.VertexLinks;
                if (destinations == null) continue;

                Edge current_edge;
                for (int j = 0; j < destinations.Length; j++)
                {
                    current_edge = destinations[j];
                    double new_length = current_vertex.TotalLength + current_edge.Weight;
                    if (new_length < current_edge.Target.TotalLength)
                    {
                        current_edge.Target.TotalLength = new_length;
                        current_edge.Target.SourceOfTotalLength = current_vertex;

                    }
                }

            }

            string path = this.Vertices[this.Vertices.Length - 1].Name;
            Vertex v = this.Vertices[this.Vertices.Length - 1];
            while (v.SourceOfTotalLength != null)
            {
                path = v.SourceOfTotalLength.Name + " - " + path;
                v = v.SourceOfTotalLength;
            }
            Console.WriteLine(this.Vertices[this.Vertices.Length - 1].TotalLength);
            Console.WriteLine(path);

            this.RestoreVertices();
        }



        public void BFS()
        {
            Console.WriteLine("BFS From Graph Class;");
            int v = Vertices.Length;
            Queue<Vertex> q = new Queue<Vertex>(v);
            q.Enqueue(this.Vertices[0]);
            this.Vertices[0].Visited = true;

            Vertex current_vertex;
            Edge[] destinations;
            while (q.Count > 0)
            {
                current_vertex = q.Dequeue();
                destinations = current_vertex.VertexLinks;
                for (int i = 0; i < destinations.Length; i++)
                {
                    if (destinations[i].Target.Visited == false)
                    {
                        q.Enqueue(destinations[i].Target);
                        destinations[i].Target.Visited = true;
                        Console.WriteLine(current_vertex.Name + " - "
                                          + destinations[i].Target.Name);
                    }
                }

            }
            RestoreVertices();
        }

        public void RestoreVertices()
        {
            foreach (Vertex v in this.Vertices)
            {
                v.Visited = false;
                v.TotalLength = 0;
                v.SourceOfTotalLength = null;
            }
        }


        public void DFS()
        {
            Console.WriteLine("DFS From Graph Class;");
            DFSRecursion(this.Vertices[0]);
            RestoreVertices();
        }
        private void DFSRecursion(Vertex current_vertex)
        {
            current_vertex.Visited = true;
            Edge[] destinations = current_vertex.VertexLinks;
            for (int i = 0; i < destinations.Length; i++)
            {
                if (destinations[i].Target.Visited == false)
                {
                    Console.WriteLine(current_vertex.Name + " - "
                                                  + destinations[i].Target.Name);
                    DFSRecursion(destinations[i].Target);
                }
            }

        }

    }

    public class Vertex
    {
        public string Name;
        public bool Visited;

        public double TotalLength;
        public Vertex SourceOfTotalLength;

        public Edge[] VertexLinks;
    }
    public class Edge
    {
        public double Weight;
        public Vertex Source;
        public Vertex Target;

        public Edge(Vertex source, Vertex target, double weight = 0)
        {
            this.Source = source;
            this.Target = target;
            this.Weight = weight;
        }
    }
}

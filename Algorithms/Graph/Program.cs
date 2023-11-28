using Graph2;
namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prim's Min Spanning Tree
            PrimMinimumSpanningTree.MST();

            //Breadth First Search & Depth First Search
            Graph g = new Graph(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" });
            g.AddEdges(0, new int[] { 1, 2 });
            g.AddEdges(1, new int[] { 0, 3, 4 });
            g.AddEdges(2, new int[] { 0, 3, 5 });
            g.AddEdges(3, new int[] { 1, 2, 4 });
            g.AddEdges(4, new int[] { 1, 5 });
            g.AddEdges(5, new int[] { 2, 3, 4, 7 });
            g.AddEdges(6, new int[] { 7, 8 });
            g.AddEdges(7, new int[] { 5, 6, 8 });
            g.AddEdges(8, new int[] { 6, 7 });

            g.BFS();
            g.DFS();

            ////Dijkstra's Shortest Path
            //Graph g2 = new Graph2.Graph(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" });

            //g2.AddEdges(0, new int[] { 1, 2, 3 }, new double[] { 2, 4, 3 });

            //g2.AddEdges(1, new int[] { 4, 5, 6 }, new double[] { 7, 4, 6 });
            //g2.AddEdges(2, new int[] { 4, 5, 6 }, new double[] { 3, 2, 4 });
            //g2.AddEdges(3, new int[] { 4, 5, 6 }, new double[] { 4, 1, 5 });

            //g2.AddEdges(4, new int[] { 7, 8 }, new double[] { 1, 4 });
            //g2.AddEdges(5, new int[] { 7, 8 }, new double[] { 6, 3 });
            //g2.AddEdges(6, new int[] { 7, 8 }, new double[] { 3, 3 });

            //g2.AddEdges(7, new int[] { 9 }, new double[] { 3 });
            //g2.AddEdges(8, new int[] { 9 }, new double[] { 4 });

            //g2.Dijkstra();

        }
    }
}
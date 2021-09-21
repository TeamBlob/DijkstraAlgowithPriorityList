using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class Graph
    {
        public int noOfVertex { get; set; }
        public int[,] matrixG;
        public LinkedList<Edge>[] adjacencylist;

        public Graph(int noOfVertex)
        {
            this.noOfVertex = noOfVertex;
            matrixG = new int[noOfVertex, noOfVertex];
            adjacencylist = new LinkedList<Edge>[noOfVertex];

            //initialize adjacency lists for all the vertices
            for (int i = 0; i < noOfVertex; i++)
            {
                adjacencylist[i] = new LinkedList<Edge>();
            }

        }
        public void addEdges(int u, int v, int weight)
        {
            // For Matrix
            matrixG[u, v] = weight;
            matrixG[v, u] = weight;

            // Adjacency List
            Edge edge = new Edge(u, v, weight);
            adjacencylist[u].AddFirst(edge);

            edge = new Edge(v, u, weight);
            adjacencylist[v].AddFirst(edge); //for undirected graph

        }
        public void PrintMatrix()
        {
            Console.Write("       ");
            for (int i = 0; i < noOfVertex; i++)
            {
                Console.Write("{0}  ", i);
            }

            Console.WriteLine();

            for (int i = 0; i < noOfVertex; i++)
            {
                if (i < 10)
                    Console.Write("{0} | [ ", i);
                else
                    Console.Write("{0}  [ ", i);

                for (int j = 0; j < noOfVertex; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" &,");
                    }
                    else if (matrixG[i, j] == 0)
                    {
                        Console.Write(" .,");
                    }
                    else
                    {
                        Console.Write(" {0},", matrixG[i, j]);
                    }

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }
        public void PrintList()
        {
            for(int i = 0; i < adjacencylist.Length; i++)
            {
                Console.Write("{0} |", i);
                for(int j = 0; j < adjacencylist[i].Count; j++)
                {
                    Console.Write(" -> {0}", adjacencylist[i].ElementAt(j).v);
                }
                Console.Write("\r\n");
            }
            Console.Write("\r\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(16);
            g.addEdges(0, 1, 1); // Index 0
            g.addEdges(0, 2, 1); //a

            g.addEdges(1, 4, 1); //b
            g.addEdges(1, 3, 3);

            g.addEdges(2, 5, 1); //c 
            g.addEdges(2, 3, 3);

            g.addEdges(3, 7, 8); //d

            g.addEdges(4, 6, 1); //e
            g.addEdges(4, 7, 3);

            g.addEdges(5, 7, 3); //f
            g.addEdges(5, 8, 1);

            g.addEdges(6, 9, 3); //g
            g.addEdges(6, 11, 1);

            g.addEdges(7, 9, 8); //h
            g.addEdges(7, 10, 8);
            g.addEdges(7, 12, 3);

            g.addEdges(8, 10, 3); //i
            g.addEdges(8, 13, 1);

            g.addEdges(9, 14, 3); //j

            g.addEdges(10, 15, 3); //k

            g.addEdges(11, 14, 1); //l

            g.addEdges(12, 14, 1); //m
            g.addEdges(12, 15, 1);

            g.addEdges(13, 15, 1); //n


            g.PrintMatrix();
            Console.In.ReadLine();

            dijkstraAlgo(g, 0);
            Console.In.ReadLine();
        }
        static void dijkstraAlgo(Graph g, int src)
        {
            PriorityQueue toVisit = new PriorityQueue();
            List<int> visited = new List<int>();
            int[] dist = new int[g.noOfVertex]; //keeps track of the shortest distance between two nodes
            int[] prev = new int[g.noOfVertex]; //keeps track of the ‘origin’ verticies of any given node

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = Int32.MaxValue; //sets the value to infinity (or as close as possible
                prev[i] = -1; //sets all the previous location values to null
            }
            dist[src] = 0;

            toVisit.Enqueue(src, -1, 0); //this preps the priority queue for use from the start node

            Vertex temp; //a temp node, declared outside to save memory

            List<int> neighbors; //a list which will hold all the neighbors of any given node for later use

            int source; //a string which will later hold the origin name of any given Dequeue
            int costOfMove; //an int which will later hold the cost of a move between any two points

            while (!toVisit.isQueueEmpty())
            {
                temp = toVisit.Dequeue();
                source = temp.u;
                neighbors = Neighbors(g, source);
                visited.Add(source);
                foreach (int vertex in neighbors)
                {
                    if (!visited.Contains(vertex))
                    {
                        costOfMove = EdgeCost(g, source, vertex) + dist[source];
                        toVisit.Enqueue(vertex, source, costOfMove);

                        if (costOfMove < dist[vertex])
                        {
                            dist[vertex] = costOfMove;
                            prev[vertex] = source;
                        }
                    }
                }
            }
            Console.WriteLine("Vertex   Distance from Source\n");
            for (int i = 0; i < g.noOfVertex; ++i)
                Console.WriteLine("{0} \t\t {1}\n", i, dist[i]);
        }
        private static List<int> Neighbors(Graph g,int source)
        {
            List<int> tempNeighbors = new List<int>();
            for (int i = 0; i < g.noOfVertex; i++){
                if (g.matrixG[source, i] == 0)
                    continue;
                tempNeighbors.Add(i);
            }

            return tempNeighbors;
        }
        private static int EdgeCost(Graph g, int source, int vertex)
        {
            return g.matrixG[source, vertex];
        }


    }
}

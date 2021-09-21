using Project_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class Program
    {
        static Dictionary<string, long> dataCaption = new Dictionary<string, long>(); // Case Number
        
        static Random r = new Random();
        static void Main(string[] args)
        {

            PracticePriorityQueue();
            Console.WriteLine("Type any key to continue...");
            Console.In.ReadLine();
            PracticeHeapQueue();
            Console.WriteLine("Type any key to continue...");
            Console.In.ReadLine();
        }
        static void PracticePriorityQueue()
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
            Console.WriteLine("Type any key to continue...");
            Console.In.ReadLine();
            dijkstraAlgo(g, 0);
        }
        static void PracticeHeapQueue()
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

            g.PrintList();
            Console.WriteLine("Type any key to continue...");
            Console.In.ReadLine();
            dijkstra_GetMinDistances(g, 0);
        }
        static void Perform_N_Test()
        {
            double pqTimeTaken = 0;
            double hqTimeTaken = 0;

            Console.WriteLine("Generating New Graph, Enter The No Of Vertex: ");
            string stringNoOfVertex = Console.In.ReadLine(); // Input Number of Vertex

            Console.WriteLine("Enter the Numver of Trials: ");
            string trial = Console.In.ReadLine(); // Input Number of Trial Run

            Graph g = generateGraph(Convert.ToInt32(stringNoOfVertex)); // Generate Graph

            for (int i = 0; i < Convert.ToInt32(trial); i++)
            {
                int s = r.Next(0, g.noOfVertex); // Randomly Generate New Source
                pqTimeTaken += Perform_n_PriorityTest(g, s, Convert.ToInt32(trial));
                hqTimeTaken += Perform_n_HeapTest(g, s, Convert.ToInt32(trial));
            }

            PQ_n_Test(g, pqTimeTaken, Convert.ToInt32(trial));
            HQ_n_Test(g, hqTimeTaken, Convert.ToInt32(trial));
        }
        static double Perform_n_PriorityTest(Graph g, int s, int trial)
        {
            double timeTaken = 0;

            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            dijkstraAlgo(g, s);
            watch.Stop();
            timeTaken = watch.Elapsed.TotalMilliseconds;

            return timeTaken;
        }
        static void PQ_n_Test(Graph g, double timeTaken, int trial)
        {
            string testCase = $"Priority Queue Test of {g.noOfVertex}";
            string method = "Priority Queue";
            int size = g.noOfVertex;
            timeTaken = timeTaken / Convert.ToDouble(trial);
            Console.WriteLine($"Priority Queue Test Average Execution Time: {timeTaken} ms");
            TestCase newText = new TestCase(testCase, method, size, timeTaken, trial);
            newText.AppendNText();
        }
        static double Perform_n_HeapTest(Graph g, int s, int trial)
        {
            double timeTaken = 0;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            dijkstra_GetMinDistances(g, s);
            watch.Stop();
            timeTaken += watch.Elapsed.TotalMilliseconds;
            return timeTaken;
        }
        static void HQ_n_Test(Graph g, double timeTaken, int trial)
        {
            string testCase = $"Heap Queue Test of {g.noOfVertex}";
            string method = "HeapMin";
            int size = g.noOfVertex;
            timeTaken = timeTaken / Convert.ToDouble(trial);
            Console.WriteLine($"HeapMin Test Average Execution Time: {timeTaken} ms");
            TestCase newText = new TestCase(testCase, method, size, timeTaken, trial);
            newText.AppendNText();
        }
        static void Perform_S_Test()
        {
            Graph g = generateGraph(100); // Generate Graph
            Perform_s_PriorityTest(g);
            Perform_s_HeapTest(g);
        }
        static void Perform_s_PriorityTest(Graph g)
        {
            double timeTaken = 0;
            double total = 0;
            for (int i = 0; i < g.noOfVertex; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Reset();
                watch.Start();
                dijkstraAlgo(g, i);
                watch.Stop();
                timeTaken = watch.Elapsed.TotalMilliseconds;
                total += timeTaken;
                PQ_s_Test(g, timeTaken, i);
            }
            total = total / g.noOfVertex;

            string path = $@"Priority Queue {g.noOfVertex} Vertex.txt";
            string input = $"Total {total} ms";
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }
        static void PQ_s_Test(Graph g, double timeTaken, int s)
        {
            string testCase = $"Priority Queue of {g.noOfVertex} |V| From Source {s}";
            string method = $"Priority Queue {g.noOfVertex} Vertex";
            int size = g.noOfVertex;
            Console.WriteLine($"Priority Queue Test Average Execution Time: {timeTaken} ms");
            TestCase newText = new TestCase(testCase, method, size, timeTaken, 1);
            newText.AppendSText();
        }
        static void Perform_s_HeapTest(Graph g)
        {
            double timeTaken = 0;
            double total = 0;
            for (int i = 0; i < g.noOfVertex; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Reset();
                watch.Start();
                dijkstra_GetMinDistances(g, i);
                watch.Stop();
                timeTaken = watch.Elapsed.TotalMilliseconds;
                total += timeTaken;
                HQ_s_Test(g, timeTaken, i);
            }
            total = total / g.noOfVertex;

            string path = $@"Heap Queue {g.noOfVertex} Vertex.txt";
            string input = $"Total {total} ms";

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }
        static void HQ_s_Test(Graph g, double timeTaken, int s)
        {
            string testCase = $"Heap Queue of {g.noOfVertex} |V| From Source {s}";
            string method = $"Heap Queue {g.noOfVertex} Vertex";
            int size = g.noOfVertex;
            Console.WriteLine($"Heap Queue Test Average Execution Time: {timeTaken} ms");
            TestCase newText = new TestCase(testCase, method, size, timeTaken, 1);
            newText.AppendSText();
        }
        static Graph generateGraph(int noOfVertex)
        {
            Graph g = new Graph(noOfVertex);
            int w = 0; //
            int t;
            for (int i = 0; i < noOfVertex; i++)
            {
                for(int j = 0; j < noOfVertex; j++)
                {
                    if (i != j)
                    {
                        g.addEdges(i, j, r.Next(1, 10));
                    }
                        
                }
            }
            return g;
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
            
            Console.WriteLine("Dijkstra Algorithm: (Adjacency Matrix + Priority Queue)");
            for (int i = 0; i < g.noOfVertex; ++i)
            {
                Console.WriteLine("Source Vertex: " + src + " to vertex " + i +
                " distance: " + dist[i]);
            }
            
                
        }
        private static List<int> Neighbors(Graph g, int source)
        {
            List<int> tempNeighbors = new List<int>();
            for (int i = 0; i < g.noOfVertex; i++)
            {
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
        static void dijkstra_GetMinDistances(Graph g, int sourceVertex)
        {
            int INFINITY = Int32.MaxValue;
            bool[] SPT = new bool[g.noOfVertex];

            // create heapNode for all the vertices
            HeapNode[] distance = new HeapNode[g.noOfVertex];
            for (int i = 0; i < g.noOfVertex; i++)
            {
                distance[i] = new HeapNode();
                distance[i].vertex = i;
                distance[i].distance = INFINITY;
            }

            //decrease the distance for the first index
            distance[sourceVertex].distance = 0;

            //add all the vertices to the MinHeap
            MinHeap minHeap = new MinHeap(g.noOfVertex);
            for (int i = 0; i < g.noOfVertex; i++)
            {
                minHeap.Enqueue(distance[i]);
            }
            //while minHeap is not empty
            while (!minHeap.isEmpty())                                      // Loop |V| times
            {
                //extract the min
                HeapNode extractedNode = minHeap.Dequeue();                 // O(Log V)

                //extracted vertex
                int extractedVertex = extractedNode.vertex;
                SPT[extractedVertex] = true;

                //iterate through all the adjacent vertices
                LinkedList<Edge> list = g.adjacencylist[extractedVertex];
                for (int i = 0; i < list.Count; i++)
                {
                    Edge edge = list.ElementAt(i);
                    int destination = edge.v;
                    // only if destination vertex is not present in SPT
                    if (SPT[destination] == false)
                    {
                        // check if distance needs an update or not
                        // means check total weight from source to vertex_V is less than
                        // the current distance value, if yes then update the distance
                        int newKey = distance[extractedVertex].distance + edge.w;
                        int currentKey = distance[destination].distance;
                        if (currentKey > newKey)
                        {
                            decreaseKey(minHeap, newKey, destination);      // O(Log V)
                            distance[destination].distance = newKey;
                        }
                    }
                }
            }
            //print SPT
            printDijkstra(g, distance, sourceVertex);

        }
        static void decreaseKey(MinHeap minHeap, int newKey, int vertex)
        {

            //get the index which distance's needs a decrease;
            int index = minHeap.indexes[vertex];

            //get the node and update its value
            HeapNode node = minHeap.queue[index];
            node.distance = newKey;
            minHeap.bubbleUp(index);
        }
        static void printDijkstra(Graph g, HeapNode[] resultSet, int sourceVertex)
        {
            Console.WriteLine("Dijkstra Algorithm: (Adjacency List + Min Heap)");
            for (int i = 0; i < g.noOfVertex; i++)
            {
                Console.WriteLine("Source Vertex: " + sourceVertex + " to vertex " + +i +
                " distance: " + resultSet[i].distance);
            }
        }
    }
}

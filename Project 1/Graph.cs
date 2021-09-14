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
        
        public Graph(int noOfVertex)
        {
            this.noOfVertex = noOfVertex;
            this.matrixG = new int[noOfVertex, noOfVertex];
        }
        public void addEdges(int u, int v, int weight)
        {
            matrixG[u, v] = weight;
            matrixG[v, u] = weight;
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
                if(i < 10)
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
    }
}

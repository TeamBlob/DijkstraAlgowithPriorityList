using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class Edge
    {
        public int u { get; set; } // Source Vertex
        public int v { get; set; } // Destination Vertex
        public int w { get; set; } // Cost of Travel
        public Edge(int u, int v, int w) // For Graph Adjency List
        {
            this.u = u;
            this.v = v;
            this.w = w;
        }
    }
}

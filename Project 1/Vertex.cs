using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class Vertex : IComparable
    {
        public int u { get; set; } // Source Vertex
        public int v { get; set; } // Destination Vertex
        public int w { get; set; } // Cost of Travel

        public Vertex(int u, int v, int w)
        {
            this.u = u;
            this.v = v;
            this.w = w;
        }
        public int CompareTo(object obj)
        {
            Vertex inNode = (Vertex)obj;
            int inValue = inNode.w;

            if(inValue > w)
                return -1;
            else if (inValue == w)
                return 0;
            else
                return 1;

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    /*
        * This is the priority queue for the Dijkstra pathing algorithm.  It keeps as sorted list
        * (with the smallest at the bottom) of all paths that still need to be checked. The main
        * methods are Enqueue, which adds a path, Dequeue, which removes a path, and Peek, which
        * checks to see if there is anything left to check.  The class itself uses a List of
        * ‘vertNode’ objects (the code for which follows this class) which use IComparable to allow
        * sorting of the list.  Each vertNode holds the source, the destination, and the cost of any
        * given path between two points.
    */

    public class PriorityQueue
    {
        private List<Vertex> queue;

        public PriorityQueue()
        {
            queue = new List<Vertex>();
        }

        public void Enqueue(int u, int v, int weight)// u = Source Vertex, v = The Vertex Connected to u
        {
            //
            //add input to list and sort list by cost
            //
            Vertex input = new Vertex(u, v, weight);

            queue.Add(input);
            queue.Sort();
        }
        public int Peek()
        {
            if (queue.Count > 0)
                return queue[0].u;
            return -1;
        }

        public Vertex Dequeue()
        {
            //
            //pop off next out, and move everything down one in the list
            //
            Vertex deQueueVertex = queue[0];

            if (queue.Count > 1)
            {
                for (int i = 0; i < queue.Count() - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                queue.Remove(queue[queue.Count - 1]); //cuts off the last thing in the queue
            }
            else
            {
                queue.Remove(queue[0]); //if there was only one thing, it cuts it out
            }
            return deQueueVertex;
        }
        public bool isQueueEmpty()
        {
            if (queue.Count > 0)
                return false;
            return true;
        }
    }
}

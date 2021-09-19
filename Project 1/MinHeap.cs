using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{

    public class MinHeap
    {
        public int size;
        public int currentSize;
        public HeapNode[] queue;
        public int[] indexes; //will be used to decrease the distance

        public MinHeap(int size)
        {
            this.size = size;
            queue = new HeapNode[size + 1];
            indexes = new int[size];
            queue[0] = new HeapNode();
            queue[0].distance = Int32.MinValue;
            queue[0].vertex = -1;
            currentSize = 0;
        }
        public void display()
        {
            for (int i = 0; i <= currentSize; i++)
            {
                Console.WriteLine(" " + queue[i].vertex + " distance " + queue[i].distance);
            }
            Console.WriteLine("________________________");
        }
        public void Enqueue(HeapNode x)
        {
            currentSize++;
            int idx = currentSize;
            queue[idx] = x;
            indexes[x.vertex] = idx;
            bubbleUp(idx);
        }

        public void bubbleUp(int pos)
        {
            int parentIdx = pos / 2;
            int currentIdx = pos;
            while (currentIdx > 0 && queue[parentIdx].distance > queue[currentIdx].distance)
            {
                HeapNode currentNode = queue[currentIdx];
                HeapNode parentNode = queue[parentIdx];

                //swap the positions
                indexes[currentNode.vertex] = parentIdx;
                indexes[parentNode.vertex] = currentIdx;

                swap(currentIdx, parentIdx);

                currentIdx = parentIdx;
                parentIdx = parentIdx / 2;
            }
        }
        public HeapNode Dequeue()
        {
            HeapNode min = queue[1];
            HeapNode lastNode = queue[currentSize];
            // update the indexes[] and move the last node to the top
            indexes[lastNode.vertex] = 1;
            queue[1] = lastNode;
            queue[currentSize] = null;
            sinkDown(1);
            currentSize--;
            return min;
        }
        public void sinkDown(int k)
        {
            int smallest = k;
            int leftChildIdx = 2 * k;
            int rightChildIdx = 2 * k + 1;
            if (leftChildIdx < heapSize() && queue[smallest].distance > queue[leftChildIdx].distance) 
            {
                smallest = leftChildIdx;
            }
            if (rightChildIdx < heapSize() && queue[smallest].distance > queue[rightChildIdx].distance)
            {
                smallest = rightChildIdx;
            }
            if (smallest != k)
            {

                HeapNode smallestNode = queue[smallest];
                HeapNode kNode = queue[k];

                //swap the positions
                indexes[smallestNode.vertex] = k;
                indexes[kNode.vertex] = smallest;
                swap(k, smallest);
                sinkDown(smallest);
            }
        }
        public void swap(int a, int b)
        {
            HeapNode temp = queue[a];
            queue[a] = queue[b];
            queue[b] = temp;
        }
        public bool isEmpty()
        {
            return currentSize == 0;
        }
        public int heapSize()
        {
            return currentSize;
        }
    }
}

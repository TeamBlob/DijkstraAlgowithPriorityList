using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class HeapExample
    {
        public List<int> array;
        public HeapExample()
        {
            int[] l = { 1, 2, 3, 4, 5, 6, 7 };
            array = new List<int>(l);
        }
        public void heapifying(int i)
        {
            if (2 * i <= array.Count)
            {
                int leftSubTree = 2 * i;
                int rightSubTree = leftSubTree + 1;
                heapifying(leftSubTree); // heapifying(left subtree of H);
                heapifying(rightSubTree); // heapifying(right subtree of H);

                int k = array[i - 1]; //root(H);
                heapfix(i, k);

            }

        }
        public void heapfix(int i, int k)
        {
            if (2 * i > array.Count)
            {
                array[i - 1] = k;
                return;
            }


            int LargerSH = findMaxWeight(2 * i);
            if (k >= array[LargerSH - 1])
            {
                // insert k in root of H;
                array[i - 1] = k;
            }
            else
            {
                //insert LargerSH’s root key in root of H;
                int temp = array[i - 1];
                array[i - 1] = array[LargerSH - 1];
                array[LargerSH - 1] = temp;
                heapfix(LargerSH, temp);
            }

        }
        private int findMaxWeight(int i)
        {
            if (array.Count > i)
                return i;

            if (array[i - 1] >= array[i])
                return i;
            return i + 1;
        }
        private void heapSort()
        {
            int n = array.Count;
            for (int i = n; i >= 1; i--)
            {
                int curMax = getMax();
                deleteMax(i, n);
                // as result, H has i – 1 elements
                array.Add(curMax);
                // insert curMax in sorted list
            }

        }
        private int getMax()
        {
            return array[0];
        }
        private void deleteMax(int i, int n)
        {
            int k = array[n - 1]; //copy the rightmost element on the lowest level to k;
            array[0] = k; //delete the rightmost element on the lowest level;
            array.RemoveAt(n - 1);
            heapfix(1, k);
        }
    }
}

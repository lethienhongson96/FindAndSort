using System;
using System.Collections.Generic;
using System.Text;

namespace FindAndSort
{
    class FindAndSort
    {
        public int[] CreateArr(int side)
        {
            int[] arr = new int[side];
            Random rnd = new Random();

            for (int i = 0; i < side; i++)
            {
                arr[i] = rnd.Next(30, 60);
            }

            return arr;
        }

        public bool IsSymmetryArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int indexMin = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (min > arr[j])
                    {
                        min = arr[j];
                        indexMin = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[indexMin];
                arr[indexMin] = temp;
            }
        }
        public void PrintArr(int[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]} ";
            }
            Console.WriteLine(str);
        }

        public bool checkSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] >= arr[i + 1])
                {
                    return false;
                }
            }

            this.SelectionSort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public int Find(int[] arr, int val)
        {
            if (!this.checkSorted(arr))
            {
                return -1;
            }

            int low = 0;
            int high = arr.Length - 1;
            while (high >= low)
            {
                int mid = (low + high) / 2;
                if (val < arr[mid])
                    high = mid - 1;
                else if (val == arr[mid])
                    return mid;
                else
                    low = mid + 1;
            }
            return -1;

        }


    }
}

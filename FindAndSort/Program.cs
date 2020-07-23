using System;
using System.Collections.Generic;

namespace FindAndSort
{
    class Program
    {
        public static FindAndSort findAndSort = new FindAndSort();
        public static int[] arr=new int[0];
        static void Main(string[] args)
        {
            do
            {
                Menu();
                int checkpress = Convert.ToInt32(Console.ReadLine());
                if (checkpress==5)
                {
                    break;
                }
                switch (checkpress)
                {
                    case 1:
                        Console.WriteLine("enter the side for array");
                        int side = Convert.ToInt32(Console.ReadLine());
                        arr = findAndSort.CreateArr(side);
                        findAndSort.PrintArr(arr);
                        break;

                    case 2:
                        if (!findAndSort.IsSymmetryArray(arr))
                        {
                            Console.WriteLine("not symmetry !!!");
                        }

                        else
                        {
                            Console.WriteLine("yes/ it is symmetry");
                        }
                        break;

                    case 3:
                        findAndSort.SelectionSort(arr);
                        findAndSort.PrintArr(arr);
                        break;

                    case 4:
                        Console.WriteLine("enter the number you looking for: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        if (findAndSort.BinarySearch(arr,num)==-1)
                        {
                            Console.WriteLine("not found or not yet sort");
                        }

                        else
                        {
                            Console.WriteLine($"found at {findAndSort.BinarySearch(arr, num)}");
                        }
                        break;
                }
            } while (true);

        }

        public static void Menu()
        {
            Console.WriteLine("1/create arr");
            Console.WriteLine("2/check Symmetry Array");
            Console.WriteLine("3/sort arr");
            Console.WriteLine("4/find index of value:");
            Console.WriteLine("5/exits:");
        }
    }
}

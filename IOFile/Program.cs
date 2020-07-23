using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IOFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Collections\FindAndSort\IOFile\data";
            Directory.CreateDirectory(path);

            string fileName = "InputData.txt";
            List<string> liststr = new List<string>(){"3 4","1 2 3 4","5 6 7 8","9 10 11 15"};
            FileService.WriteFile($@"{path}\{fileName}", liststr);
            
            List<int> data = FileService.ReadFile($@"{path}\{fileName}");
            int col = data[1];
            data.RemoveAt(0);
            data.RemoveAt(0);

            string outputFileName = "OutputData.txt";
            List<string> result = new List<string>();
            result.Add($"sum = {data.Sum()}");
            result.Add($"amount of prime = {CountPrime(data)}");
            result.Add($"amount of oddnum = {CountOdd(data)}");
            result.Add($"sum of border= {SumOfBoder(data,col)}");

            List<int> multi = MultibyThree(data);
            string multiStr = "";
            foreach (int el in multi)
            {
                multiStr += $"{el} ";
            }
            result.Add($"multi by 3= {multiStr}");
            FileService.WriteFile($@"{path}\{outputFileName}", result);
        }

        public static int CountOdd(List<int> data)
        {
            int count = 0;
            foreach (int el in data)
            {
                if (el%2!=0)
                {
                    count++;
                }
            }
            return count;
        }

        public static bool isPrime(int num)
        {
            if (num < 2)
                return false;
            for (int i=2;i< num; i++)
            {
                if (num%i==0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountPrime(List<int> data)
        {
            int count = 0;
            foreach (int el in data)
            {
                if (isPrime(el))
                {
                    count++;
                }
            }
            return count;
        }

        public static int SumOfBoder(List<int> data,int col)
        {
            int sum = 0;
            for (int i=0;i<col;i++)
            {
                sum += data[i];
            }
            return sum;
        }

        public static List<int> MultibyThree(List<int> data)
        {
            List<int> mutilListed = new List<int>();
            for (int i=0;i<data.Count;i++)
                mutilListed.Add(data[i]*3);
            return mutilListed;
        }
    }
}

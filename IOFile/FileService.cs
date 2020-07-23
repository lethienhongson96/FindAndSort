using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOFile
{
    class FileService
    {
        public static List<int> ReadFile(string filePath)
        {
            var data = new List<int>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                        data.AddRange(FileService.GetList(line));
                }
            }
            return data;
        }

        public static void WriteFile(string filePath, List<string> data)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static List<int> GetList(string strNum)
        {
            List<int> arrlist = new List<int>();
            string str = "";
            for (int i = 0; i < strNum.Length; i++)
            {
                if (strNum[i] != ' ')
                {
                    str += strNum[i];
                    if (i == strNum.Length - 1)
                        arrlist.Add(int.Parse(str));
                }

                else
                {
                    arrlist.Add(int.Parse(str));
                    str = "";
                }
            }
            return arrlist;
        }
    }
}

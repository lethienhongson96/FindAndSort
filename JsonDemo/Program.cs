using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace JsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"D:\AccessModifier\FindAndSort\JsonDemo\Data\Input_Ex1.json";
            var outFilePath1 = @"D:\AccessModifier\FindAndSort\JsonDemo\Data\Output_Ex1.json";
            var outFilePath2 = @"D:\AccessModifier\FindAndSort\JsonDemo\Data\Output_Ex2.json";

            // bien result chua toan bo noi dung cua file input
            var result = new Payload();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Payload>(data);
            }

            result.datalists.ForEach(el => Console.WriteLine(el));
            var result1 = new Response()
            {
                datalists = new List<Resdatalist>()
            };
            //lay du lieu tu result.datalists sang 
            foreach (var item in result.datalists)
            {
                result1.datalists.Add(new Resdatalist()
                {
                    sum = item.GetSum()
                }); 
            }

            using (StreamWriter sw = File.CreateText(outFilePath1))
            {
                var data = JsonConvert.SerializeObject(result1);
                sw.Write(data);
            }

            //bai 2
            var result2 = new Response1()
            {
                datalists1 = new List<Resdatalist1>()
            };

            foreach (var item in result.datalists)
            {
                result2.datalists1.Add(new Resdatalist1()
                {
                    multia=item.multi(item.a),
                    multib = item.multi(item.b),
                    multic = item.multi(item.c)
                });
            }

            using (StreamWriter sw = File.CreateText(outFilePath2))
            {
                var data = JsonConvert.SerializeObject(result2);
                sw.Write(data);
            }
        }
    }
    class Payload
    {
        public List<datalist> datalists { get; set; }
    }

    public class datalist
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public int GetSum() => this.a + this.b + this.c;
        public int multi(int x) => x * 2;
        public override string ToString() => $"a={this.a} b={this.b} c={this.c}";
    }

    //bai 1
    public class Response
    {
        public List<Resdatalist> datalists { get; set; }
    }

    public class Resdatalist
    {
        public int sum;
    }

    //bai 2
    public class Response1
    {
        public List<Resdatalist1> datalists1 { get; set; }
    }

    public class Resdatalist1 
    {
        public int multia;
        public int multib;
        public int multic;
    }
}

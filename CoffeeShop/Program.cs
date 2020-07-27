using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CoffeeShop
{
    class Program
    {
        public static TableList tableList = new TableList()
        {
            Tables = new List<Table>()
        };
        public static string filepath = @"D:\AccessModifier\FindAndSort\CoffeeShop\data\order.json";
        static void Main(string[] args)
        {
            do
            {
                Menu();
                int checkPress = Convert.ToInt32(Console.ReadLine());
                if (checkPress == 3)
                    break;
                switch (checkPress)
                {
                    case 1:
                        AddTable();

                        break;
                    case 2:
                        Console.WriteLine("nhap so ban muon thanh toan");
                        int tableNo = Convert.ToInt32(Console.ReadLine());
                        if (CheckTable(tableNo)==false)
                        {
                            PrintBill(tableNo);
                            tableList.Findtable(tableNo).checkUse = false;
                            tableList.Findtable(tableNo).drinkList.Clear();

                            using (StreamWriter sw = File.CreateText(filepath))
                            {
                                var data = JsonConvert.SerializeObject(tableList);
                                sw.Write(data);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ko tim thay so ban nay");
                        }
                        
                        break;
                }
            } while (true);

        }

        public static void PrintBill(int tablenum)
        {
            var filepath = @"D:\AccessModifier\FindAndSort\CoffeeShop\data";
            var billfilename = $"Bill_{DateTime.Now.ToString("ddMMyyyyhhmm")}.json";
            tableList = ReadFile();

            if (tableList.Findtable(tablenum).checkUse==false)
            {
                Console.WriteLine("ban da thanh toan");
            }
            else
            {
                Bill bill = new Bill();
                bill.TableNum = tablenum;
                bill.PrintAt = DateTime.Now;
                bill.orderdetails = tableList.Findtable(tablenum).drinkList;
                bill.CalculateTotal();

                using (StreamWriter sw = File.CreateText($@"{filepath}\{billfilename}"))
                {
                    var data = JsonConvert.SerializeObject(bill);
                    sw.Write(data);
                }
            }
            
        }

       

        public static bool CheckTable(int TableNum)
        {
            var result = ReadFile();
            if (result.Tables.Contains(result.Findtable(TableNum)))
            {
                return false;
            }
            else
                return true;
        }

        public static TableList ReadFile()
        {
            var result = new TableList();
            using (StreamReader sr = File.OpenText(filepath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<TableList>(data);
            }
            return result;
        }

        public static void AddTable()
        {
            Table table = new Table();
            Console.WriteLine("nhap so ban:");
            tableList = ReadFile();
            table.tableNumber = Convert.ToInt32(Console.ReadLine());
            if (CheckTable(table.tableNumber))
            {
                tableList.Tables.Add(table);
                do
                {
                    Console.WriteLine("1/add do uong");
                    Console.WriteLine("2/thoat!!!");
                    int checkpress = Convert.ToInt32(Console.ReadLine());
                    if (checkpress == 2)
                        break;
                    else
                    {
                        AddDrink(table.tableNumber);
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            var data = JsonConvert.SerializeObject(tableList);
                            sw.Write(data);
                        }
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("ban da ton tai");
                tableList.Tables.Remove(tableList.Findtable(table.tableNumber));
                tableList.Tables.Add(table);
                do
                {
                    Console.WriteLine("1/add do uong");
                    Console.WriteLine("2/thoat!!!");
                    int checkpress = Convert.ToInt32(Console.ReadLine());
                    if (checkpress == 2)
                        break;
                    else
                    {
                        AddDrink(table.tableNumber);
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            var data = JsonConvert.SerializeObject(tableList);
                            sw.Write(data);
                        }
                    }
                } while (true);
            }
        }

        public static void AddDrink(int tableNum)
        {
            Drink drink = new Drink();
            Console.WriteLine("ten thuc uong:");
            drink.drinkName = Console.ReadLine();

            Console.WriteLine("gia:");
            drink.price = Convert.ToDouble(Console.ReadLine());
            tableList.Findtable(tableNum).Adddrink(drink);
        }

        public static void Menu()
        {
            Console.WriteLine("1/chon ban: ");
            Console.WriteLine("2/thanh toan: ");
            Console.WriteLine("3/thoat: ");
        }
    }
}

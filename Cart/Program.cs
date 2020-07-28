using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Cart
{
    class Program
    {
        public static Product product6 = new Product("iphone 6", 6000000, 1);
        public static Product product7 = new Product()
        {
            name = "iphone 7",
            price = 7000000,
            amount = 1
        };
        public static Product product8 = new Product()
        {
            name = "iphone 8",
            price = 8000000,
            amount = 1
        };
        public static Product product9 = new Product()
        {
            name = "iphone 9",
            price = 9000000,
            amount = 1
        };
        public static string filepath = @"D:\AccessModifier\FindAndSort\Cart\data\Products.json";
        public static Cart cart = new Cart();

        public static string filepathOut = @"D:\AccessModifier\FindAndSort\Cart\data\";
        public static string billfilename = $"Bill_{DateTime.Now.ToString("ddMMyyyyhhmm")}.json";
        static void Main(string[] args)
        {

            do
            {
                Menu();
                int checkPress = Convert.ToInt32(Console.ReadLine());
                if (checkPress == 4)
                    break;
                switch (checkPress)
                {
                    case 1:
                        Readfile();
                        ProductsMenu();
                        int checkNum = Convert.ToInt32(Console.ReadLine());
                        switch (checkNum)
                        {
                            case 1:
                                cart.AddProduct(product6);
                                WirteFile();
                                break;
                            case 2:
                                cart.AddProduct(product7);
                                WirteFile();
                                break;
                            case 3:
                                cart.AddProduct(product8);
                                WirteFile();
                                break;
                            case 4:
                                cart.AddProduct(product9);
                                WirteFile();
                                break;
                        }
                        break;
                    case 2:
                        Readfile();
                        cart.ViewCart();
                        break;
                    case 3:
                        Readfile();
                        if (cart.checkSale)
                        {
                            cart.checkSale = false;
                            using (StreamWriter sw = File.CreateText($@"{filepathOut}\{billfilename}"))
                            {
                                var data = JsonConvert.SerializeObject(cart);
                                sw.Write(data);
                            }
                            cart.SaleAll();
                            WirteFile();
                        }
                        else
                            Console.WriteLine("gio hang trong");
                        break;
                }

            } while (true);

        }

        public static void Menu()
        {
            Console.WriteLine("1/them san pham vao gio hang");
            Console.WriteLine("2/xem san pham da co trong gio hang");
            Console.WriteLine("3/thanh toan");
            Console.WriteLine("4/thoat");
        }

        public static void ProductsMenu()
        {
            Console.WriteLine("1/iphone 6");
            Console.WriteLine("2/iphone 7");
            Console.WriteLine("3/iphone 8");
            Console.WriteLine("4/iphone 9");
        }

        public static void Readfile()
        {
            using (StreamReader sr = File.OpenText(filepath))
            {
                var data = sr.ReadToEnd();
                cart = JsonConvert.DeserializeObject<Cart>(data);
            }
        }

        public static void WirteFile()
        {
            using (StreamWriter sw = File.CreateText(filepath))
            {
                var data = JsonConvert.SerializeObject(cart);
                sw.Write(data);
            }
        }
    }
}

using System;

namespace Product
{
    class Program
    {
        //ban hang soluong- neu ko co thi ko hien thi ra phai co nhap hang
        //xem duoc don nhap hang theo ngay
        //
        static void Main(string[] args)
        {
            Product product1 = new Product(20000000,"iphone6","apple");
            Product product2 = new Product(20000000, "galaxy7", "samsung");
            Product product3 = new Product(20000000, "xiaomi", "realme");
            Product product4 = new Product(20000000, "nokia1080", "nokia");
            Product product5 = new Product(25000000, "iphone10", "apple");

            Product productList = new Product();
            productList.AddProduct(product1);
            productList.AddProduct(product2);
            productList.AddProduct(product3);
            productList.AddProduct(product4);
            productList.AddProduct(product5);

            productList.Show();

            Console.WriteLine("------------------------------");
            productList.findListPrice(21000000, 26000000);
            Console.WriteLine("------------------------------");
            productList.findListType("apple");
            Console.WriteLine("------------------------------");

            Console.WriteLine("enter id of product to import amount:");
            int id=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter amount of product to import amount:");
            int amount=Convert.ToInt32(Console.ReadLine());

            string date = "07/23/2020";
            productList.ImportProduct(id, amount);
            productList.ImportProduct(id, amount);
            productList.ImportProduct(id, amount);
            Console.WriteLine("enter id of product to import amount:");
            int id1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter amount of product to import amount:");
            int amount1 = Convert.ToInt32(Console.ReadLine());
            productList.ImportProduct(id1, amount1);

            productList.ViewHistory(DateTime.Parse(date));
            productList.SellProduct(id, 5);
            /* productList.Show();*/
            Console.WriteLine("----------------------------------");


            productList.ViewHistory(DateTime.Parse(date));
            

        }
    }
}

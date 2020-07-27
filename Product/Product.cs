using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    //tao lop product co cac truong
    // - price -id -name - loai
    //chon khoang gia se xuat hien cac san pham nam o trong khoang gia
    //chon tat cac san pham theo loai
    //29-07-2020// List<Import> import
    //tinh tien loi
    class Product
    {
        public double price { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        List<Import> ImportList = new List<Import>();
        List<Product> Products = new List<Product>();

        //constructor
        public Product() { }

        public Product(double price, string name, string type)
        {
            this.price = price;
            this.name = name;
            this.type = type;
            setID();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void findListPrice(double minPrice, double maxPrice)
        {
            List<Product> results = Products.FindAll(
            delegate (Product pro)
            {
                return pro.price >= minPrice && pro.price <= maxPrice;
            }
            );

            if (results.Count == 0)
                Console.WriteLine("not found");
            else
                results.ForEach(el => Console.WriteLine(el));
        }
        public void Show() => Products.ForEach(el => Console.WriteLine(el));

        public override string ToString() => $"price={this.price} id={this.id} name={this.name} type={this.type}";

        private void setID()
        {
            Random rnd = new Random();
            this.id = rnd.Next(100, 1000);
        }

        public void findListType(string type)
        {
            List<Product> results = Products.FindAll(
            delegate (Product pro) { return pro.type == type; });

            if (results.Count == 0)
                Console.WriteLine("not found");
            else
                results.ForEach(el => Console.WriteLine(el));
        }

        public void ImportProduct(int id, int amount, double impPrice)
        {
            if (this.FindID(id) == -1)
                Console.WriteLine($"not found id: {id}");
            else
            {
                Import importob = new Import();
                importob.product = Products[this.FindID(id)];
                importob.createAt = DateTime.Today;
                importob.quantity = amount;//so luong import vao
                importob.QuantityActual = amount;
                importob.CheckWare = true;
                importob.ImpPrice = impPrice;
                ImportList.Add(importob);
            }
        }

        public void SellProduct(int id, int amount, double sellPrice)
        {
            if (this.FindID(id) == -1)
                Console.WriteLine($"not found id: {id}");
            else
            {
                int totalAmount = this.CountAmount(id);
                if (totalAmount >= amount)
                {
                    Import importob = new Import();
                    importob.product = Products[this.FindID(id)];
                    importob.createAt = DateTime.Today;
                    importob.quantity = amount;
                    Console.WriteLine($"Profit is: {CaculatorProfit(id, amount, sellPrice)}");
                    SellingInWare(id, amount);
                    importob.CheckWare = false;
                    importob.SellPrice = sellPrice;
                    ImportList.Add(importob);
                }
                else
                    Console.WriteLine("over amount");
            }
        }
        private int CountAmount(int id)
        {
            List<Import> result = FindListByID(id);
            int totalProduct = 0;
            result.ForEach(el => totalProduct += el.QuantityActual);

            return totalProduct;
        }
        private List<Import> FindListByID(int id) => ImportList.FindAll(item => item.product.id == id);

        public int FindID(int id) => Products.FindIndex(item => item.id == id);

        private List<Import> FindTime(DateTime dateTime) => ImportList.FindAll(item => item.createAt == dateTime);
        public void ViewHistory(DateTime dateTime)
        {
            if (FindTime(dateTime).Count == 0)
                Console.WriteLine($"not found {dateTime}");
            else
                FindTime(dateTime).ForEach(el => Console.WriteLine(el)); 
        }
        public double CaculatorProfit(int id, int amount, double sellPrice)
        {
            double profit = 0;
            List<Import> sellingList = FindListByID(id);
            foreach (Import item in sellingList)
            {
                if (amount > item.QuantityActual)
                {
                    profit += (item.QuantityActual * sellPrice) - (item.QuantityActual * item.ImpPrice);
                    amount = amount - item.QuantityActual;

                }

                else
                {
                    profit += (amount * sellPrice) - (amount * item.ImpPrice);
                    break;
                }
            }

            return profit;
        }

        public void SellingInWare(int id, int amount)
        {
            for (int i = 0; i < ImportList.Count; i++)
            {
                if (ImportList[i].product.id == id)
                {
                    if (amount > ImportList[i].QuantityActual)
                    {
                        amount = amount - ImportList[i].QuantityActual;
                        ImportList[i].QuantityActual = 0;
                    }

                    else
                    {
                        ImportList[i].QuantityActual = Math.Abs(amount - ImportList[i].QuantityActual);
                        break;
                    }
                }
            }
        }
    }
}

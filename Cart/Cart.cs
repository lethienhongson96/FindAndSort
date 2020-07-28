using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    class Cart
    {
        public List<Product> products = new List<Product>();
        public bool checkSale = true;
        public double total { get; set; }

        public void AddProduct(Product pro)
        {
            if (products.Contains(FindProduct(pro.name)) == false)
            {
                products.Add(pro);
                FindProduct(pro.name).proTotalPrice = FindProduct(pro.name).price * FindProduct(pro.name).amount;
                CalculateTotal();
                this.checkSale = true;
            }
                
            else
            {
                FindProduct(pro.name).amount++;
                FindProduct(pro.name).proTotalPrice = FindProduct(pro.name).price * FindProduct(pro.name).amount;
                CalculateTotal();
            }
        }

        public Product FindProduct(string productName)
        {
            return products.Find
                (
                    delegate (Product pro)
                    {
                        return pro.name == productName;
                    }
                );
        }

        public void CalculateTotal()
        {
            double sum = 0;
            products.ForEach(el=>sum+=el.proTotalPrice);
            this.total = sum;
        }

        public void SaleAll()
        {
            CalculateTotal();
            this.checkSale = false;
            products.Clear();
            total = 0;
        }

        public void ViewCart() => products.ForEach(el => Console.WriteLine(el));
    }
}

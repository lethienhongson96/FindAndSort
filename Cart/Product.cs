using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    class Product
    {
        public double price { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public double proTotalPrice { get; set; }
       
        public Product(string name,double price,int amount)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
        }

        public Product()
        {

        }
        public override string ToString()
        {
            return $"name = {name}, amount = {amount}, price = {price}";
        }
    }
}

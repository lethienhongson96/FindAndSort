using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop
{
    class Drink
    {
        public string drinkName { get; set; }
        public double price { get; set; }
        public Drink()
        {

        }
        public override string ToString() =>$"name : {drinkName}, price : {price}";
    }
}

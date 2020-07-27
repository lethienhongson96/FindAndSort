using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop
{
    class Bill
    {
        public double total;
        public int TableNum { get; set; }
        public DateTime PrintAt { get; set; }
        public List<Drink> orderdetails { get; set; }
        
        public void CalculateTotal()
        {
            double sum = 0;
            orderdetails.ForEach(el=>sum+=el.price);
            this.total = sum;
        }
    }
}

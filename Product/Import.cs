using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    class Import
    {
        public Product product { get; set; }
        public int quantity { get; set; }
        public int QuantityActual { get; set; }
        public DateTime createAt { get; set; }
        public bool CheckSale;
        public double ImpPrice { get; set; }
        public double SellPrice { get; set; }
        public override string ToString()
        {
            if (CheckSale)
                return $"name: {product.name} import {quantity} real: {QuantityActual} impP: {ImpPrice} at: {createAt}";
            
            return $"name: {product.name} sell {quantity} sellPrice: {SellPrice} at: {createAt}";
        }
    }
}

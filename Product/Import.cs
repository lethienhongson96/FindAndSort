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
        /* public int QuantityActual = 0;*/
        public DateTime createAt { get; set; }
        public bool CheckSale;
        public override string ToString()
        {
            return $"name: {product.name} {(CheckSale ? "import" : "selling")} {quantity} " +
                $"real: {QuantityActual} at: {createAt}";
        }
    }
}

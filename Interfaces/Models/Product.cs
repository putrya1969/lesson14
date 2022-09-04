using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Product : IProduct
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(string model, decimal price, int quantity)
        {
            Model = model;
            Price = price;
            Quantity = quantity;
        }
    }
}

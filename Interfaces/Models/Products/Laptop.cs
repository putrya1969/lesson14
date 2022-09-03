using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    internal class Laptop : IProduct
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Laptop(string model, decimal price, int quantity)
        {
            Model = model;
            Price = price;
            Quantity = quantity;
        }

        string IProduct.ToString()
        {
            return $"{Model} - {Price} - {Quantity}";
        }
    }
}

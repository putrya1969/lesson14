using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal OrderItemPrice { get; set; }
        public OrderItem(string productModel, decimal productPrice, int quantity)
        {
            ProductName = productModel;
            Quantity = quantity;
            OrderItemPrice = productPrice*quantity;
        }
        public override string ToString()
        {
            return $"{ProductName} {Quantity} {OrderItemPrice}";
        }
        public string ToFile()
        {
            return $"{ProductName}*{Quantity}*{OrderItemPrice}";
        }
    }
}

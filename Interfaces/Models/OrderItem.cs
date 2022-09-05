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
        public OrderItem(IProduct product, int quantity)
        {
            ProductName = product.Model;
            Quantity = quantity;
            OrderItemPrice = product.Price*quantity;
        }
        public override string ToString()
        {
            return $"{ProductName}:{Quantity}:{OrderItemPrice}$";
        }
    }
}

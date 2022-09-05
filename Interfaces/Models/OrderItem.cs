using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class OrderItem
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal OrderItemPrice 
        {
            get 
            {
                return OrderItemPrice;
            }
            set
            {
                OrderItemPrice = Product.Price * Quantity;
            } 
        }

        public OrderItem(IProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Order : IOrder
    {
        public string OrderDate { get; set; }
        public string ClientFullName { get; set; }
        public OrderItem OrderItem { get; set; }
        public string OrderPrice { get; set; }

        public Order(string orderDate, string client, string product, decimal productPrice, int quantity)
        {
            
            OrderDate = orderDate;
            ClientFullName = client;
            OrderItem = new OrderItem(product, productPrice, quantity);
            OrderPrice = (productPrice * quantity).ToString();
        }

        public override string ToString()
        {
            return $"{OrderDate}\t{ClientFullName}\t{OrderItem.ProductName}\t{OrderItem.Quantity}\t{OrderItem.OrderItemPrice}\t{OrderPrice}";
        }
    }
}

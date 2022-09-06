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


        public Order(string orderDate, string client, string product, decimal productPrice, int quantity)
        {
            
            OrderDate = orderDate;
            ClientFullName = client;
            OrderItem = new OrderItem(product, productPrice, quantity);
            
        }
    }
}

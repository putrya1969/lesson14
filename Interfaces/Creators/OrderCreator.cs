using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class OrderCreator 
    {
        public IOrder CreatedOrder { get; set; }
        public OrderCreator(string orderDate, string client, string productName, decimal productPrice ,int quantity)
        {
            CreatedOrder = Create(orderDate, client, productName, productPrice, quantity);
        }
        public IOrder Create(string orderDate, string client, string productName, decimal productPrice, int quantity)
        {
            IOrder order = null;
            order = new Order(orderDate, client, productName, productPrice, quantity);
            if (IsValid(order))
                return order;
            else
                return null;
        }

        public bool IsValid(IOrder element)
        {
            return (!string.IsNullOrEmpty(element.ClientFullName)) && (!string.IsNullOrEmpty(element.OrderDate));
        }
    }
}

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
        public OrderCreator(IClient client, IProduct product, int quantity)
        {
            CreatedOrder = Create(client, product, quantity);
        }
        public IOrder Create(IClient client, IProduct product, int quantity)
        {
            IOrder order = null;
            order = new Order(client, product, quantity);
            if (IsValid(order))
                return order;
            else
                return null;
        }

        public bool IsValid(IOrder element)
        {
            return (!string.IsNullOrEmpty(element.Client)) && (!string.IsNullOrEmpty(element.OrderDate));
        }
    }
}

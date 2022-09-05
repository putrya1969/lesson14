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
        public OrderItem OrderItem { get; set; }
        public string Client { get; set; }
        public Order(IClient client, IProduct product, int quantity)
        {
            OrderDate = DateTime.Now.ToString("dd-MM-yy HH:mm");
            OrderItem = new OrderItem(product, quantity);
            Client = client.ToString();
        }
    }
}

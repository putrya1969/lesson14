using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class OrderStorage : IStorage<IOrder>
    {
        public List<IOrder> Objects { get; set; } = new List<IOrder>();

        public OrderStorage(string[] sourceArr)
        {
            for (int i = 0; i < sourceArr.Length; i++)
            {
                var orderFields = sourceArr[i].Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);

                var order = new OrderCreator(orderFields[0], 
                    orderFields[1], 
                    orderFields[2], 
                    Decimal.Parse(orderFields[3]), 
                    int.Parse(orderFields[4])).CreatedOrder;
                if (order != null)
                    Objects.Add(order);
            }
        }
    }
}

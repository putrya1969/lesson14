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
                var order = new OrderCreator(sourceArr[i]).CreatedProduct;
                if (order != null)
                    Objects.Add(order);
            }
        }
    }
}

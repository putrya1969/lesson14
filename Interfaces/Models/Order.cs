using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Order : IOrder
    {
        public DateTime OrderDate { get; set; }
        public OrderItem OrderItem { get; set; }
        IClient IOrder.Client { get; set; }
    }
}

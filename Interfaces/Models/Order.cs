using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Order
    {
        public DateTime OrderDate { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Client : Buyer
    {
        public double Discount { get; set; }
        public List<Order> Orders{ get; set; }
    }
}

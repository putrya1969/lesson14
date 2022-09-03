using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IProduct
    {
        string Model { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        string ToString();
    }
}

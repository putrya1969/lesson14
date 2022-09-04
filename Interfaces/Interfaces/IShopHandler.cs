using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IShopHandler<T>
    {
        List<T> Collection { get; set; }
        void Add();
        void Delete();
        void Process();
        void View();
    }
}

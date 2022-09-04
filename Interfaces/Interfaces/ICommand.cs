using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface ICommand<T>
    {
        string Name { get; set; }
        string Message { get; set; }
        IShopHandler<T> Handler { get; set; }
        void Execute();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IStorage<T>
    {
        List<T> Objects { get; set; }

    }
}

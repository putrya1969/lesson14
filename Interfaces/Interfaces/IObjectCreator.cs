using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IObjectCreator<T>
    {
        T Create(string sourceString);
        bool IsValid(T element);

    }
}

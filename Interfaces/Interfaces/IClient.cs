using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IClient
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string PhoneNumber { get; set; }
    }
}

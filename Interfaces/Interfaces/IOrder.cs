using System;

namespace Interfaces
{
    internal interface IOrder
    {
        DateTime OrderDate { get; set; }
        IClient Client { get; set; }
        OrderItem OrderItem { get; set; }
    }
}
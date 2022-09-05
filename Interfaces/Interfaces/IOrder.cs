using System;

namespace Interfaces
{
    internal interface IOrder
    {
        string OrderDate { get; set; }
        string Client { get; set; }
        OrderItem OrderItem { get; set; }
    }
}
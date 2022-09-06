using System;

namespace Interfaces
{
    internal interface IOrder
    {
        string OrderDate { get; set; }
        string ClientFullName { get; set; }
        OrderItem OrderItem { get; set; }
    }
}
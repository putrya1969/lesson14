using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Client : IClient
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public double Discount { get; set; }
        public List<Order> Orders { get; set; }

        public Client(string lastName, string firstName, string phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {PhoneNumber}";
        }
    }
}

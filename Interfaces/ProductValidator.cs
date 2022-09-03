using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ProductValidator : IProductValidator
    {
        public bool IsValid(IProduct product)
        {
            return product.Model != "" && (product.Price > 0);
        }
    }
}

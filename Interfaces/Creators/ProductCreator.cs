using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ProductCreator : IObjectCreator<IProduct>
    {
        public IProduct CreatedProduct { get; set; }
        public ProductCreator(string inputString)
        {
            CreatedProduct = Create(inputString);
        }
        public IProduct Create(string sourceString)
        {
            var objectFields = sourceString.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            IProduct product = null;
            if (objectFields.Length == 3)
                 product = new Product(objectFields[0], Decimal.Parse(objectFields[1]), int.Parse(objectFields[2]));
            if (IsValid(product))
                return product;
            else
                return null;
        }

        public bool IsValid(IProduct element)
        {
            return (element.Model != "")&&(element.Price > 0);
        }
    }
}

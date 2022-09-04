using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ProductStorage : IStorage<IProduct>
    {
        public List<IProduct> Objects { get; set; } = new List<IProduct>();

        public ProductStorage(string[] sourceArr)
        {
            for (int i = 0; i < sourceArr.Length; i++)
            {
                var product = new ProductCreator(sourceArr[i]).CreatedProduct;
                if (product != null)
                    Objects.Add(product);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IStoreProduct
    {
        List<IProduct> Products { get; set; }
        IProduct GetProduct(string Model);
        void AddProduct(IProduct product);
        void UpdateProductQuantity(string name, int quantity);
        void DeleteProduct(IProduct product);
        void ViewProducts();
    }
}

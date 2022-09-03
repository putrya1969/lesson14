using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class InternetShop
    {
        IStoreProduct storeProduct;
        public InternetShop(IStoreProduct products)
        {
            storeProduct = products;
        }
    }
}

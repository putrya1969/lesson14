using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ProductHandler : IStoreProduct
    {
        public List<IProduct> Products { get; set; }

        public ProductHandler(List<IProduct> products)
        {
            Products = products;
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }

        public void DeleteProduct(IProduct product)
        {
            Products = Products.Except(new List<IProduct> { product }).ToList();
        }

        public IProduct GetProduct(string model)
        {
            return Products.Where(p => p.Model == model).FirstOrDefault();
        }

        public void UpdateProductQuantity(string name, int quantity)
        {
            var product = GetProduct(name);
            product.Quantity = quantity;
        }

        public void ViewProducts()
        {
            foreach (var item in Products)
            {
                Console.WriteLine(item);
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces
{
    internal class ProductHandler : IShopHandler<IProduct>
    {
        readonly string productHandlerManual = 
            "For add new product press\t\t 'A'\n" +
            "For delete product press\t\t 'D'\n" +
            "For view all products press\t\t 'V'\n" +
            "For edit product press\t\t 'E'\n" +
            "For search product press\t\t 'F'\n" +
            "For return to previous menu press\t 'R'";
        public List<IProduct> Collection { get; set; }

        public ProductHandler(List<IProduct> collection)
        {
            Collection = collection;
        }

        public void Add()
        {
            Console.WriteLine("Enter new product in format\nModel Price Quantity\ndivided by '*'");
            var product = new ProductCreator(Console.ReadLine()).CreatedProduct;
            if (product == null)
            {
                Console.WriteLine("Invalid format data\nProduct don't added");
                return;
            }
            Collection.Add(product);
        }

        public void Delete()
        {
            View();
            Console.WriteLine("Enter product Id for delete");
            var index = int.Parse(Console.ReadLine());
            Collection = Collection.Except(new List<IProduct> { Collection[index] }).ToList();
        }

        public void Delete(int index)
        {
            Collection = Collection.Except(new List<IProduct> { Collection[index] }).ToList();
        }

        public void View()
        {
            foreach (var item in Collection)
            {
                Console.WriteLine($"{Collection.IndexOf(item)}. {item}");
            };
        }

        public void Edit()
        {
            View();
            Console.WriteLine("Enter product Id for edit");
            var index = int.Parse(Console.ReadLine());
            Delete(index);
            Add();
        }

        public void Search()
        {
            Console.WriteLine("Searshing product by model");
            string subStr = Console.ReadLine();
            var searched = Collection.Where(p => p.Model.Contains(subStr)).ToList();
            foreach (var item in searched)
            {
                Console.WriteLine(item);
            }
        }

        public void Process()
        {
            Console.Clear();
            Console.WriteLine(productHandlerManual);
            string[] validUserInput = new string[] { "a", "d", "v", "e", "f", "r" };
            bool toExit;
            do
            {
                toExit = true;
                string userInput = Console.ReadLine().ToLower();
                if (validUserInput.Contains(userInput))
                {
                    userInput = userInput.ToLower();
                    switch (userInput)
                    {
                        case "a":
                            {
                                Add();
                                break;
                            }
                        case "d":
                            {
                                Delete();
                                break;
                            }
                        case "v":
                            {
                                View();
                                break;
                            }
                        case "e":
                            {
                                Edit();
                                break;
                            }
                        case "f":
                            {
                                Search();
                                break;
                            }
                        case "r":
                            {
                                toExit = false;
                                break;
                            }
                    }
                }


            } while (toExit);
        }

        private bool ValidInput(string[] validValue, string userKey)
        {
            return validValue.Contains(userKey);
        }
    }
}

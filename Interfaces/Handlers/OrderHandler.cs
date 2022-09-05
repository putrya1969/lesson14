using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class OrderHandler : IShopHandler<IOrder>
    {
        readonly string orderHandlerManual = "For add new order press\t\t 'A'\n" +
                                            "For view all orders press\t\t 'V'\n" +
                                            "For edit order press\t\t\t 'E'\n" +
                                            "For search order press\t\t 'F'\n" +
                                            "For return to previous menu press\t 'R'";
        public List<IOrder> Collection { get; set; }
        readonly string fileName = Path.Combine(Environment.CurrentDirectory, "orders.txt");
        public OrderHandler(List<IOrder> collections)
        {
            Collection = collections;

        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            string[] validUserInput = new string[] { "a", "v", "e", "f", "r" };
            bool toExit;
            do
            {
                Console.Clear();
                Console.WriteLine(orderHandlerManual);
                toExit = false;
                string userInput = Console.ReadLine().ToLower();
                if (validUserInput.Contains(userInput))
                {
                    userInput = userInput.ToLower();
                    Console.Clear();
                    switch (userInput)
                    {
                        case "a":
                            {
                                Add();
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
                                toExit = true;
                                break;
                            }
                    }
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            } while (!toExit);
        }

        private void Search()
        {
            throw new NotImplementedException();
        }

        private void Edit()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            throw new NotImplementedException();
        }
    }
}

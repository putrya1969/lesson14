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
        readonly string orderHandlerManual = "For add new order press\t\t\t 'A'\n" +
                                            "For view all orders press\t\t 'V'\n" +
                                            "For return to previous menu press\t 'R'";
        public List<IOrder> Collection { get; set; }
        public IShopHandler<IProduct> ProductHandler { get; }
        public IShopHandler<IClient> ClientHandler { get; }
        public IFileSaver<IOrder> OrderSaver { get; }

        readonly string fileName = Path.Combine(Environment.CurrentDirectory, "orders.txt");
        public OrderHandler(List<IOrder> collections, IShopHandler<IProduct> productHandler, IShopHandler<IClient> clientHandler)
        {
            Collection = collections;
            ProductHandler = productHandler;
            ClientHandler = clientHandler;
            OrderSaver = new OrderSaver(fileName);
        }

        public void Add()
        {
            ClientHandler.View();
            Console.WriteLine("Enter client Id");
            int clientId = int.Parse(Console.ReadLine());
            if ((clientId < 0) || (clientId > ClientHandler.Collection.Count))
            {
                Console.WriteLine("Invalid value clientId");
                return;
            }
            IClient currentClient = ClientHandler.Collection[clientId];
            Console.Clear();
            ProductHandler.View();
            Console.WriteLine("Enter product Id");
            int productId = int.Parse(Console.ReadLine());
            if ((productId < 0) || (productId > ProductHandler.Collection.Count))
            {
                Console.WriteLine("Invalid value productId");
                return;
            }
            IProduct currentProduct = ProductHandler.Collection[productId];
            Console.WriteLine("Enter quantity of product");
            var quantity = int.Parse(Console.ReadLine());
            if (quantity > currentProduct.Quantity)
            {
                Console.WriteLine("Invalid value quantity");
                return;
            }
            Console.Clear();
            var order = new OrderCreator(DateTime.Now.ToString("dd-MM-yy HH:mm"),
                currentClient.ToString(), 
                currentProduct.Model,
                currentProduct.Price,
                quantity).CreatedOrder;
            if (order == null)
            {
                Console.WriteLine("Invalid format data\nProduct wasn't added");
                return;
            }
            Collection.Add(order);
            OrderSaver.AppendData(order);
            currentProduct.Quantity -= quantity;
            ProductHandler.ResaveCollection();
            Console.WriteLine($"Was created new order:\n{order.ToString()}");
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            string[] validUserInput = new string[] { "a", "v", "r" };
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
            Console.WriteLine("#  Date\t\t\tClient\t\t\t\tModel\t\tQty\tPrice\tTotal price");
            foreach (var item in Collection)
            {
                Console.WriteLine($"{Collection.IndexOf(item)}. {item}");
            }
        }

        public void ResaveCollection()
        {
            throw new NotImplementedException();
        }
    }
}

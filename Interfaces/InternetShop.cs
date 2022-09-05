using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class InternetShop
    {
        IShopHandler<IClient> _clients;
        IShopHandler<IProduct> _products;
        IShopHandler<IOrder> _orders;
        //public InternetShop(IShopHandler<IProduct> products, IShopHandler<IClient> clients, IShopHandler<IOrder> orders)
        public InternetShop(IShopHandler<IProduct> products, IShopHandler<IClient> clients)
        {
            _products = products;
            _clients = clients;
            //_orders = orders;
            ViewStartMenu();
            var userSelect = Console.ReadLine();
            switch (userSelect)
            {
                case "1":
                    {
                        _clients.Process();
                        break;
                    }
                case "2":
                    {
                        _products.Process();
                        break;
                    }
                case "3":
                    {
                        _orders.Process();
                        break;
                    }
            }
        }



        public void ViewStartMenu()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<<Welcome to the internet store>>");
            stringBuilder.AppendLine("For work with Clients press\t '1'");
            stringBuilder.AppendLine("For work with Products press\t '2'");
            stringBuilder.AppendLine("For work with Orders press\t '3'");
            Console.WriteLine(stringBuilder);
        }
    }
}

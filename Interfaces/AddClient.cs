using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class AddClient : ICommand<IClient>
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public IShopHandler<IClient> Handler { get; set; }

        public AddClient(string name, string message, IShopHandler<IClient> shopHandler)
        {
            Name = name;
            Message = message;
            Handler = shopHandler;
        }

        public void Execute()
        {
        }
    }
}

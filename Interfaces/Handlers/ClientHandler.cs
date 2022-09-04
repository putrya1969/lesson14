using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ClientHandler : IShopHandler<IClient>
    {
        public List<IClient> Collection { get; set; }

        public void Add()
        {
        }

        public void Delete()
        {
        }

        public void Edit(string lastName, IClient editedClient)
        {
            var pos = Collection.FindIndex(c => c.LastName == lastName);
            Collection[pos] = editedClient;
        }

        public IClient Get(string lastName)
        {
            return Collection.Where(c=> c.LastName == lastName).FirstOrDefault();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            foreach (var item in Collection)
            {
                Console.WriteLine(item);
            };
        }
    }
}

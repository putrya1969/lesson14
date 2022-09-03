using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Handlers
{
    internal class ClientHandler : IStoreClient
    {
        public List<IClient> Clients { get; set; }

        public void AddClient(IClient client)
        {
            Clients.Add( client);
        }

        public void DeleteClient(IClient client)
        {
            Clients = Clients.Except(new List<IClient>() {client}).ToList();
        }

        public void EditClient(string lastName, IClient editedClient)
        {
            var pos = Clients.FindIndex(c => c.LastName == lastName);
            Clients[pos] = editedClient;
        }

        public IClient GetClient(string lastName)
        {
            return Clients.Where(c=> c.LastName == lastName).FirstOrDefault();
        }

        public void ViewClients()
        {
            foreach (var item in Clients)
            {
                Console.WriteLine(item);
            };
        }

    }
}

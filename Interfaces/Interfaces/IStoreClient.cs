using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IStoreClient
    {
        List<IClient> Clients { get; set; }
        IClient GetClient(string lastName);
        void AddClient(IClient client);
        void EditClient(string lastName, IClient editedClient);
        void DeleteClient(IClient client);
        void ViewClients();

    }
}

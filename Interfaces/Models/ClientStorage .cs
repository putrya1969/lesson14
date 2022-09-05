using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ClientStorage : IStorage<IClient>
    {
        public List<IClient> Objects { get; set; } = new List<IClient>();

        public ClientStorage(string[] sourceArr)
        {
            for (int i = 0; i < sourceArr.Length; i++)
            {
                var client = new ClientCreator(sourceArr[i]).CreatedClient;
                if (client != null)
                    Objects.Add(client);
            }
        }
    }
}

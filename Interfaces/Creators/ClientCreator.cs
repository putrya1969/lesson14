using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ClientCreator : IObjectCreator<IClient>
    {
        public IClient CreatedClient { get; set; }
        public ClientCreator(string inputString)
        {
            CreatedClient = Create(inputString);
        }
        public IClient Create(string sourceString)
        {
            var objectFields = sourceString.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            IClient client = null;
            if (objectFields.Length == 3)
                 client = new Client(objectFields[0], objectFields[1], objectFields[2]);
            if (IsValid(client))
                return client;
            else
                return null;
        }

        public bool IsValid(IClient element)
        {
            return (!string.IsNullOrEmpty(element.LastName))&&(!string.IsNullOrEmpty(element.FirstName));
        }
    }
}

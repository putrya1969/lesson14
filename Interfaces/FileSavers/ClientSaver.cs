using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class ClientSaver : IFileSaver<IClient>
    {
        public string FileName { get; }
        public ClientSaver(string fileName)
        {
            FileName = fileName;
        }

        public void AppendData(IClient element)
        {
            if (File.Exists(FileName))
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine($"\n{element.LastName}*{element.FirstName}*{element.PhoneNumber}");
                }
            }
            else
                throw new Exception($"Append data error\n File {FileName} not exists");

        }

        public void ReSaveData(List<IClient> elements)
        {
            if(File.Exists(FileName))
                File.Delete(FileName);
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                foreach (var item in elements)
                {
                    sw.WriteLine($"{item.LastName}*{item.FirstName}*{item.PhoneNumber}");
                }
            }
        }
    }
}

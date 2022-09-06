using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces
{
    class OrderSaver : IFileSaver<IOrder>
    {
        public string FileName { get; }
        public OrderSaver(string fileName)
        {
            FileName = fileName;
        }

        public void AppendData(IOrder element)
        {
            if (File.Exists(FileName))
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine($"\n{element.OrderDate}*{element.ClientFullName}*{element.OrderItem.ToFile()}");
                }
            }
            else
                throw new Exception($"Append data error\n File {FileName} not exists");

        }

        public void ReSaveData(List<IOrder> elements)
        {
            if(File.Exists(FileName))
                File.Delete(FileName);
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                foreach (var item in elements)
                {
                    sw.WriteLine($"{item.OrderDate}*{item.ClientFullName}*{item.OrderItem.ToFile()}");
                }
            }
        }
    }
}

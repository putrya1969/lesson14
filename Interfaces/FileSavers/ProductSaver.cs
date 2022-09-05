using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class ProductSaver : IFileSaver<IProduct>
    {
        public string FileName { get; }
        public ProductSaver(string fileName)
        {
            FileName = fileName;
        }

        public void AppendData(IProduct element)
        {
            if (File.Exists(FileName))
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine($"\n{element.Model}*{element.Price}*{element.Quantity}");
                }
            }
            else
                throw new Exception($"Append data error\n File {FileName} not exists");

        }

        public void ReSaveData(List<IProduct> elements)
        {
            if(File.Exists(FileName))
                File.Delete(FileName);
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                foreach (var item in elements)
                {
                    sw.WriteLine($"{item.Model}*{item.Price}*{item.Quantity}");
                }
            }
        }
    }
}

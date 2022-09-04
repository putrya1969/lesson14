using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class FileHandler
    {
        public string FullFileName { get;}
        public string[] Content { get; set; } = null;

        public FileHandler(string fullFileName)
        {
            FullFileName = fullFileName;
            if (File.Exists(FullFileName))
                Content = GetFileContent();
            else
                Console.WriteLine("Файл не найден!");
        }

        private string[] GetFileContent()
        {
            StringBuilder content = null;

            using (StreamReader reader = new StreamReader(FullFileName))
            {
                content = new StringBuilder(reader.ReadToEnd());
            }
            return content.ToString().Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

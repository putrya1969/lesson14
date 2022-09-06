using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces
{
    internal class ProductHandler : IShopHandler<IProduct>
    {
        readonly string productHandlerManual = 
            "For add new product press\t\t 'A'\n" +
            "For delete product press\t\t 'D'\n" +
            "For view all products press\t\t 'V'\n" +
            "For edit product press\t\t\t 'E'\n" +
            "For search product press\t\t 'F'\n" +
            "For return to previous menu press\t 'R'";
        readonly string fileName = Path.Combine(Environment.CurrentDirectory, "products.txt");
        public List<IProduct> Collection { get; set; }
        public IFileSaver<IProduct> ProductSaver { get; }

        public ProductHandler(List<IProduct> collection)
        {
            Collection = collection;
            ProductSaver = new ProductSaver(fileName);
        }

        public void Add()
        {
            Console.WriteLine("Enter new product in format\nModel Price Quantity\ndivided by '*'");
            var product = new ProductCreator(Console.ReadLine()).CreatedProduct;
            if (product == null)
            {
                Console.WriteLine("Invalid format data\nProduct wasn't added");
                return;
            }
            Collection.Add(product);
            ProductSaver.AppendData(product);
        }

        public void Delete()
        {
            View();
            Console.WriteLine("Enter product Id for delete");
            var index = int.Parse(Console.ReadLine());
            Collection.RemoveAt(index);
            ProductSaver.ReSaveData(Collection);
        }

        public void Delete(int index)
        {
            Collection.RemoveAt(index);
            ProductSaver.ReSaveData(Collection);
        }

        public void View()
        {
            foreach (var item in Collection)
            {
                Console.WriteLine($"{Collection.IndexOf(item)}. {item}");
            };
        }

        public void Edit()
        {
            View();
            Console.WriteLine("Enter product Id for edit");
            var index = int.Parse(Console.ReadLine());
            var editedElement = Collection[index];
            var editedText = ReadInputWithDefault($"{editedElement.Model}*{editedElement.Price}*{editedElement.Quantity}");
            var product = new ProductCreator(editedText).CreatedProduct;
            if (product == null)
            {
                Console.WriteLine("Invalid format data\nProduct wasn't edited");
                return;
            }
            Collection[index] = product;
            ProductSaver.ReSaveData(Collection);
        }

        public void Search()
        {
            Console.WriteLine("Searshing product by model");
            string subStr = Console.ReadLine();
            var searched = Collection.Where(p => p.Model.Contains(subStr)).ToList();
            foreach (var item in searched)
            {
                Console.WriteLine(item);
            }
        }

        public void Process()
        {
            string[] validUserInput = new string[] { "a", "d", "v", "e", "f", "r" };
            bool toExit;
            do
            {
                Console.Clear();
                Console.WriteLine(productHandlerManual);
                toExit = false;
                string userInput = Console.ReadLine().ToLower();
                if (validUserInput.Contains(userInput))
                {
                    userInput = userInput.ToLower();
                    Console.Clear();
                    switch (userInput)
                    {
                        case "a":
                            {
                                Add();
                                break;
                            }
                        case "d":
                            {
                                Delete();
                                break;
                            }
                        case "v":
                            {
                                View();
                                break;
                            }
                        case "e":
                            {
                                Edit();
                                break;
                            }
                        case "f":
                            {
                                Search();
                                break;
                            }
                        case "r":
                            {
                                toExit = true;
                                break;
                            }
                    }
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            } while (!toExit);
        }

        private static string ReadInputWithDefault(string defaultValue, string caret = "> ")
        {
            Console.WriteLine(); // make sure we're on a fresh line

            List<char> buffer = defaultValue.ToCharArray().Take(Console.WindowWidth - caret.Length - 1).ToList();
            Console.Write(caret);
            Console.Write(buffer.ToArray());
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(Math.Max(Console.CursorLeft - 1, caret.Length), Console.CursorTop);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Math.Min(Console.CursorLeft + 1, caret.Length + buffer.Count), Console.CursorTop);
                        break;
                    case ConsoleKey.Home:
                        Console.SetCursorPosition(caret.Length, Console.CursorTop);
                        break;
                    case ConsoleKey.End:
                        Console.SetCursorPosition(caret.Length + buffer.Count, Console.CursorTop);
                        break;
                    case ConsoleKey.Backspace:
                        if (Console.CursorLeft <= caret.Length)
                        {
                            break;
                        }
                        var cursorColumnAfterBackspace = Math.Max(Console.CursorLeft - 1, caret.Length);
                        buffer.RemoveAt(Console.CursorLeft - caret.Length - 1);
                        RewriteLine(caret, buffer);
                        Console.SetCursorPosition(cursorColumnAfterBackspace, Console.CursorTop);
                        break;
                    case ConsoleKey.Delete:
                        if (Console.CursorLeft >= caret.Length + buffer.Count)
                        {
                            break;
                        }
                        var cursorColumnAfterDelete = Console.CursorLeft;
                        buffer.RemoveAt(Console.CursorLeft - caret.Length);
                        RewriteLine(caret, buffer);
                        Console.SetCursorPosition(cursorColumnAfterDelete, Console.CursorTop);
                        break;
                    default:
                        var character = keyInfo.KeyChar;
                        if (character < 32) // not a printable chars
                            break;
                        var cursorAfterNewChar = Console.CursorLeft + 1;
                        if (cursorAfterNewChar > Console.WindowWidth || caret.Length + buffer.Count >= Console.WindowWidth - 1)
                        {
                            break; // currently only one line of input is supported
                        }
                        buffer.Insert(Console.CursorLeft - caret.Length, character);
                        RewriteLine(caret, buffer);
                        Console.SetCursorPosition(cursorAfterNewChar, Console.CursorTop);
                        break;
                }
                keyInfo = Console.ReadKey(true);
            }
            Console.Write(Environment.NewLine);

            return new string(buffer.ToArray());
        }

        private static void RewriteLine(string caret, List<char> buffer)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(caret);
            Console.Write(buffer.ToArray());
        }

        public void ResaveCollection()
        {
            ProductSaver.ReSaveData(Collection);
        }
    }
}

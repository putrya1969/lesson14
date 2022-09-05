using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ClientHandler : IShopHandler<IClient>
    {
        readonly string clientHandlerManual =
            "For add new client press\t\t 'A'\n" +
            "For delete client press\t\t 'D'\n" +
            "For view all clients press\t\t 'V'\n" +
            "For edit client press\t\t\t 'E'\n" +
            "For search client press\t\t 'F'\n" +
            "For return to previous menu press\t 'R'";
        readonly string fileName = Path.Combine(Environment.CurrentDirectory, "clients.txt");
        public List<IClient> Collection { get; set; }
        public IFileSaver<IClient> ClientSaver { get; }

        public ClientHandler(List<IClient> collection)
        {
            Collection = collection;
            ClientSaver = new ClientSaver(fileName);
        }

        public void Add()
        {
            Console.WriteLine("Enter new client in format\nLastName FirstName PhoneNumber\ndivided by '*'");
            var client = new ClientCreator(Console.ReadLine()).CreatedClient;
            if (client == null)
            {
                Console.WriteLine("Invalid format data\nProduct wasn't added");
                return;
            }
            Collection.Add(client);
            ClientSaver.AppendData(client);
        }

        public void Delete()
        {
            View();
            Console.WriteLine("Enter client Id for delete");
            var index = int.Parse(Console.ReadLine());
            Collection.RemoveAt(index);
            ClientSaver.ReSaveData(Collection);
        }

        public void Delete(int index)
        {
            Collection.RemoveAt(index);
            ClientSaver.ReSaveData(Collection);
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
            var editedText = ReadInputWithDefault($"{editedElement.LastName}*{editedElement.FirstName}*{editedElement.PhoneNumber}");
            var client = new ClientCreator(editedText).CreatedClient;
            if (client == null)
            {
                Console.WriteLine("Invalid format data\nProduct wasn't edited");
                return;
            }
            Collection[index] = client;
            ClientSaver.ReSaveData(Collection);
        }

        public void Search()
        {
            Console.WriteLine("Searshing client by last name");
            string subStr = Console.ReadLine();
            var searched = Collection.Where(p => p.LastName.Contains(subStr)).ToList();
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
                Console.WriteLine(clientHandlerManual);
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

        private bool ValidInput(string[] validValue, string userKey)
        {
            return validValue.Contains(userKey);
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
    }
}

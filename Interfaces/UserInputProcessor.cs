using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces
{
    internal class UserInputProcessor
    {
        public MenuItem rootItem { get; set; }
        public MenuItem CurrentMenuItem { get; set; }
        public AddClient SelectedCommand { get; set; }

        public UserInputProcessor(MenuItem menuItem)
        {
            rootItem = menuItem;
            CurrentMenuItem = rootItem;
        }

        public void Process()
        {
            while (CurrentMenuItem.Children != null)
            {
                PrintInfo(CurrentMenuItem);
                var keys = GetKeys();
                keys.Add("m");
                CurrentMenuItem = ProcessInput(keys);
            }
        }

        public List<String> GetKeys()
        {
            return CurrentMenuItem.Children.Select(s => s.Key).ToList();
        }

        public void PrintInfo(MenuItem menuItem)
        {
            Console.Clear();
            Console.WriteLine(menuItem.CommandName);
            foreach (var item in menuItem.Children)
            {
                Console.WriteLine($"{item.Description} press: {item.Key}");
            }
            if (menuItem.Key != "")
                Console.WriteLine($"Return to main menu press: m");
        }

        public MenuItem ProcessInput(List<string> keys)
        {
            do
            {
                var userInput = Console.ReadLine();
                if (keys.Contains(userInput))
                {
                    if (userInput == "m")
                        return rootItem;
                    return CurrentMenuItem.Children.Where(menuItem => menuItem.Key == userInput).FirstOrDefault();
                }
                else { Console.WriteLine("Invalid input"); }
            } while (true);
        }

        IEnumerable<MenuItem> FlattenAndFilter(MenuItem source, string SomeSpecialKey)
        {
            List<MenuItem> l = new List<MenuItem>();
            if (source.Key == SomeSpecialKey)
                l.Add(source);
            return
                l.Concat(source.Children.SelectMany(child => FlattenAndFilter(child, SomeSpecialKey)));
        }
    }
}

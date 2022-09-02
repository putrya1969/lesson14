using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class MenuItem
    {
        public string CommandName { get; set; }
        public string Key { get; set; }
        public string Description{ get; set; }
        public Command Command { get; set; }
        public List<MenuItem> Children { get; set; }
        public MenuItem(string commandName, string key, string description, List<MenuItem> subItems)
        {
            CommandName = commandName;
            Key = key;
            Description = description;
            Children = subItems;
        }
        public void Execute()
        {
            PrintInfo();
            var menuItem = ProcessInput(GetKeys());
            //Console.WriteLine($"{CommandName}:{Key} - {Description}");
        }

        private string[] GetKeys()
        {
            return Children.Select(s => s.Key).ToArray();
        }

        private void PrintInfo()
        {
            Console.Clear();
            foreach (var item in Children)
            {
                Console.WriteLine($"{item.CommandName} press: {item.Key}");
            }
        }



        private MenuItem ProcessInput(string[] keys)
        {
            do 
            {
                if (keys.Contains(Console.ReadLine()))
                    return null;
            } while(true);
        }

        //private MenuItem GetSubMenuItem(MenuItem menuItem, string key)
        //{
        //    return .Descendants().Where(node => node.Key == key);
        //}

        //static IEnumerable<MenuItem> Descendants(this MenuItem root)
        //{
        //    var nodes = new Stack<MenuItem>(new[] { root });
        //    while (nodes.Any())
        //    {
        //        MenuItem node = nodes.Pop();
        //        yield return node;
        //        foreach (var n in node.Children) nodes.Push(n);
        //    }
        //}
    }
}


//https://stackoverflow.com/questions/7062882/searching-a-tree-using-linq
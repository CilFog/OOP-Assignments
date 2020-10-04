using System;
using MiniProject.Classes;

namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("[[SUPER FANCY menu]]");
            menu.Add(new MenuItem("Anne", "Long list"));
            menu.Add(new MenuItem("Salle", "Long llister"));

            Console.WriteLine(menu.MenuItemList[0].Content);
            Console.WriteLine(menu.MenuItemList[1].Content);

            menu.Start();
        }
    }
}

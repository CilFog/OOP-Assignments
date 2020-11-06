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

            menu.Start();
        }
    }
}


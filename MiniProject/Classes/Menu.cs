using System;
using System.Collections.Generic;

namespace MiniProject.Classes
{
    public class Menu
    {
        public Menu(string title)
        {
            Title = title;
        }

        private int Cursor { get; set; }

        public string Title { get; set; }

        public bool Running { get; set; }

        public List<MenuItem> MenuItemList = new List<MenuItem>();

        public void Add(MenuItem item)
        {
            MenuItemList.Add(item);
        }

        public void Start()
        {
            Running = true;

            DrawMenu();
            do
            {
                HandleInput();

            } while (Running == true);

        }

        public void DrawMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Magenta;

           for(int item = 0; item < MenuItemList.Count; item++)
            {
                if(item == Cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine(MenuItemList[item].Title);


                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(MenuItemList[item].Title);
                }

            }

        }

        public void HandleInput()
        {

            ConsoleKeyInfo input = Console.ReadKey();    

            switch (input.Key)
            {
                case ConsoleKey.Escape:
                    Running = false;
                    break;

                case ConsoleKey.UpArrow:
                    if (Cursor == 0)
                    {
                        Cursor = MenuItemList.Count - 1;
                        DrawMenu();
                    }
                    else
                    {
                        Cursor--;
                        DrawMenu();
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (Cursor == (MenuItemList.Count - 1))
                    {
                        Cursor = 0;
                        DrawMenu();
                    }
                    else
                    {
                        Cursor++;
                        DrawMenu();
                    }
                    break;

                case ConsoleKey.Enter:

                    DrawMenu();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(MenuItemList[Cursor].Content);

                    break;


                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("U dumb, u shithead");
                    
                    break;
            }
        }

    }
}

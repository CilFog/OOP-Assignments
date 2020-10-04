using System;
namespace MiniProject.Classes
{
    public class MenuItem
    {
        public MenuItem(string title, string content)
        { 
            Title = title;
            Content = content;
        }

        public string Title { get; set; }

        public string Content { get; set; }

    }
}

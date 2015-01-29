using System;
using System.Collections.Generic;
using Framework.Menus;

namespace Hangman
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Constants.Width, Constants.Height);
            Console.SetBufferSize(Constants.Width, Constants.Height);
            new Menu("H A N G M E N", new List<MenuOption> { new StartOption(), new QuitOption() }).Show();
        }
    }
}

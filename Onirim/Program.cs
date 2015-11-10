using System;
using System.Collections.Generic;
using Framework.Menus;

namespace Onirim
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Constants.Width, Constants.Height);
            Console.SetBufferSize(Constants.Width, Constants.Height);
            new Menu("O N I R I M", new List<MenuOption> { new StartOption(), new QuitOption() }).Show();
        }
    }
}

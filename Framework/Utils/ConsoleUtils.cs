using System;

namespace Framework.Utils
{
    public static class ConsoleUtils
    {
        public static void WriteCentered(string format, params object[] arg)
        {
            var text = string.Format(format, arg);
            var left = Console.WindowWidth/2 - text.Length/2 + 1;
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.Write(text);
        }

        public static void WriteLineCentered(string format, params object[] arg)
        {
            var text = string.Format(format, arg);
            var left = Console.WindowWidth / 2 - text.Length / 2 + 1;
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}
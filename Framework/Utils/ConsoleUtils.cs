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

        public static void WriteColor(ConsoleColor foreground, ConsoleColor background, string format,
            params object[] args)
        {
            var previousForegroundColor = Console.ForegroundColor;
            var previousBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.Write(format, args);

            Console.ForegroundColor = previousForegroundColor;
            Console.BackgroundColor = previousBackgroundColor;
        }
    }
}
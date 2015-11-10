using System;

namespace Onirim.Cards
{
    public abstract class ColorCard : Card
    {
        public ColorCard(LocationColor color)
        {
            Color = color;
        }
        public LocationColor Color { get; private set; }

        protected ConsoleColor BackgroundColor
        {
            get
            {
                switch (Color)
                {
                    case LocationColor.Acquarium:
                        return ConsoleColor.Cyan;
                    case LocationColor.Garden:
                        return ConsoleColor.Green;
                    case LocationColor.Observatory:
                        return ConsoleColor.Red;
                    case LocationColor.Library:
                        return ConsoleColor.Yellow;
                    default:
                        return ConsoleColor.Black;
                }
            }
        }

        protected ConsoleColor ForegroundColor
        {
            get
            {
                switch (Color)
                {
                    case LocationColor.Acquarium:
                        return ConsoleColor.Black;
                    case LocationColor.Garden:
                        return ConsoleColor.Black;
                    case LocationColor.Observatory:
                        return ConsoleColor.White;
                    case LocationColor.Library:
                        return ConsoleColor.Black;
                    default:
                        return ConsoleColor.Black;
                }
            }
        }
    }
}
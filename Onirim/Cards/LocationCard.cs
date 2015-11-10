using System;
using Framework.Utils;

namespace Onirim.Cards
{
    public class LocationCard : ColorCard
    {
        public LocationCard(LocationSuit suit, LocationColor color)
            : base(color)
        {
            Suit = suit;
        }

        public LocationSuit Suit { get; private set; }

        public override void Print()
        {

            ConsoleUtils.WriteColor(ForegroundColor, BackgroundColor, Sign);
        }

        private string Sign
        {
            get
            {
                switch (Suit)
                {
                    case LocationSuit.Key:
                        return "K";
                    case LocationSuit.Moon:
                        return "M";
                    case LocationSuit.Sun:
                        return "S";
                    default:
                        throw new InvalidCastException("Suit is not supported");
                }
            }
        }
    }
}
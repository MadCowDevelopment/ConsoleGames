using System;
using Framework.Utils;

namespace Onirim.Cards
{
    public class NightmareCard : DreamCard
    {
        public override void Print()
        {
            ConsoleUtils.WriteColor(ConsoleColor.DarkBlue, ConsoleColor.Red, "N");
        }
    }
}
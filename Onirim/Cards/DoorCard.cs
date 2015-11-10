using Framework.Utils;

namespace Onirim.Cards
{
    public class DoorCard : ColorCard
    {
        public DoorCard(LocationColor color)
            : base(color)
        {
        }

        public override void Print()
        {
            ConsoleUtils.WriteColor(ForegroundColor, BackgroundColor, "D");
        }
    }
}
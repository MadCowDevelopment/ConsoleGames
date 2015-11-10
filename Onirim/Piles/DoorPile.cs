using Onirim.Cards;

namespace Onirim.Piles
{
    public class DoorPile : Pile<DoorCard>
    {
        protected override string Name
        {
            get { return "Doors"; }
        }

        protected override int Row
        {
            get { return 3; }
        }
    }
}
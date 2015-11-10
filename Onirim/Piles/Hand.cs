using Onirim.Cards;

namespace Onirim.Piles
{
    public class Hand : Pile<LocationCard>
    {
        protected override string Name
        {
            get { return "Hand"; }
        }

        protected override int Row
        {
            get { return 9; }
        }
    }
}
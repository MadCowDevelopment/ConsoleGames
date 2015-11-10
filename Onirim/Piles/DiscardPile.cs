using Onirim.Cards;

namespace Onirim.Piles
{
    public class DiscardPile : Pile<Card>
    {
        protected override string Name
        {
            get { return "Discard"; }
        }

        protected override int Row
        {
            get { return 1; }
        }
    }
}
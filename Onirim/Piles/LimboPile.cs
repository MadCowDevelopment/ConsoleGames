using Onirim.Cards;

namespace Onirim.Piles
{
    public class LimboPile : Pile<Card>
    {
        protected override string Name
        {
            get { return "Limbo"; }
        }

        protected override int Row
        {
            get { return 7; }
        }
    }
}
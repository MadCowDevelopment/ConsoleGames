using Onirim.Cards;

namespace Onirim.Piles
{
    public class LocationPile : Pile<LocationCard>
    {
        protected override string Name
        {
            get { return "Location"; }
        }

        protected override int Row
        {
            get { return 5; }
        }

        public bool CheckDoorUnlocked()
        {
            if (_cards.Count < 3) return false;
            var cardsOfSameColor = 1;
            var i = _cards.Count - 1;
            var currentCard = _cards[i--];
            var previousCard = _cards[i--];
            while (currentCard.Color == previousCard.Color)
            {
                cardsOfSameColor++;
                if (i < 0) break;
                currentCard = previousCard;
                previousCard = _cards[i--];
            }

            if (cardsOfSameColor == 0) return false;
            return cardsOfSameColor%3 == 0;
        }
    }
}
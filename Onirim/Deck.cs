using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Utils;
using Onirim.Cards;
using Onirim.Piles;

namespace Onirim
{
    public class Deck
    {
        private Queue<Card> _cardsQueue;

        public Deck()
        {
            var cards = new List<Card>();
            cards.AddRange(Enumerable.Repeat(1, 10).Select(p => new NightmareCard()));

            foreach (var color in Enum.GetValues(typeof(LocationColor)).OfType<LocationColor>())
            {
                cards.AddRange(Enumerable.Repeat(1, 2).Select(p => new DoorCard(color)));
            }

            cards.AddRange(
                Enumerable.Repeat(1, 3).Select(p => new LocationCard(LocationSuit.Key, LocationColor.Acquarium)));
            cards.AddRange(
                Enumerable.Repeat(1, 4).Select(p => new LocationCard(LocationSuit.Moon, LocationColor.Acquarium)));
            cards.AddRange(
                Enumerable.Repeat(1, 8).Select(p => new LocationCard(LocationSuit.Sun, LocationColor.Acquarium)));

            cards.AddRange(
                Enumerable.Repeat(1, 3).Select(p => new LocationCard(LocationSuit.Key, LocationColor.Garden)));
            cards.AddRange(
                Enumerable.Repeat(1, 4).Select(p => new LocationCard(LocationSuit.Moon, LocationColor.Garden)));
            cards.AddRange(
                Enumerable.Repeat(1, 7).Select(p => new LocationCard(LocationSuit.Sun, LocationColor.Garden)));

            cards.AddRange(
                Enumerable.Repeat(1, 3).Select(p => new LocationCard(LocationSuit.Key, LocationColor.Library)));
            cards.AddRange(
                Enumerable.Repeat(1, 4).Select(p => new LocationCard(LocationSuit.Moon, LocationColor.Library)));
            cards.AddRange(
                Enumerable.Repeat(1, 6).Select(p => new LocationCard(LocationSuit.Sun, LocationColor.Library)));

            cards.AddRange(
                Enumerable.Repeat(1, 3).Select(p => new LocationCard(LocationSuit.Key, LocationColor.Observatory)));
            cards.AddRange(
                Enumerable.Repeat(1, 4).Select(p => new LocationCard(LocationSuit.Moon, LocationColor.Observatory)));
            cards.AddRange(
                Enumerable.Repeat(1, 9).Select(p => new LocationCard(LocationSuit.Sun, LocationColor.Observatory)));

            Shuffle(cards);
        }

        public Card Draw()
        {
            return _cardsQueue.Count > 0 ? _cardsQueue.Dequeue() : null;
        }

        public void Print()
        {
            Console.SetCursorPosition(1, 11);
            Console.Write("Remaining cards in deck: {0}", _cardsQueue.Count);
        }

        public void ShuffleInto(LimboPile limboPile)
        {
            var cards = _cardsQueue.ToList();
            cards.AddRange(limboPile.Cards);
            limboPile.Clear();
            cards.Shuffle();
            Shuffle(cards);
        }

        public DoorCard FindDoor(LocationColor color)
        {
            var cards = _cardsQueue.ToList();
            var door = cards.OfType<DoorCard>().FirstOrDefault(p => p.Color == color);
            if (door != null)
            {
                cards.Remove(door);
                Shuffle(cards);
            }

            return door;
        }

        public bool IsEmpty()
        {
            return _cardsQueue.Count == 0;
        }

        public void Discard(int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (_cardsQueue.Count > 0) _cardsQueue.Dequeue();
            }
        }

        private void Shuffle(List<Card> cards)
        {
            cards.Shuffle();
            _cardsQueue = new Queue<Card>(cards);
        }
    }
}
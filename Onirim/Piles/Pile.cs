using System;
using System.Collections.Generic;
using Onirim.Cards;

namespace Onirim.Piles
{
    public abstract class Pile<T> where T : Card
    {
        protected readonly List<T> _cards;

        protected Pile()
        {
            _cards = new List<T>();
        }

        protected abstract string Name { get; }

        protected abstract int Row { get; }

        public IEnumerable<T> Cards
        {
            get { return _cards; }
        }

        public int CardCount
        {
            get { return _cards.Count; }
        }

        public void Add(T card)
        {
            _cards.Add(card);
        }

        public T RemoveAt(int index)
        {
            if (index >= _cards.Count)
            {
                return null;
            }

            var card = _cards[index];
            _cards.Remove(card);
            return card;
        }

        public void Remove(T card)
        {
            _cards.Remove(card);
        }

        public void Print()
        {
            Console.SetCursorPosition(1, Row);
            Console.Write("{0,10} : ", Name);
            foreach (var card in Cards)
            {
                card.Print();
                Console.Write(" ");
            }
        }

        public T GetAt(int index)
        {
            return index >= _cards.Count ? null : _cards[index];
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}
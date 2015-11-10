using System;
using System.Linq;
using System.Threading;
using Framework.Utils;
using Onirim.Cards;
using Onirim.Piles;

namespace Onirim
{
    public class OnirimGame
    {
        public OnirimGame()
        {
            DiscardPile = new DiscardPile();
            LocationPile = new LocationPile();
            LimboPile = new LimboPile();
            DoorPile = new DoorPile();
            Hand = new Hand();
            Deck = new Deck();
        }

        public void Run()
        {
            DrawFullHand();

            for (; ; )
            {
                Print();
                ProcessInput();
                bool win;
                if (CheckGameOver(out win))
                {
                    Print();
                    if (win)
                    {
                        PrintUserOption("You win!!! Press any key to continue.");
                    }
                    else
                    {
                        PrintUserOption("You lose... Press any key to continue.");
                    }
                    
                    Console.ReadKey(true);
                    break;
                }
            }
        }

        private void DrawFullHand()
        {
            do
            {
                Thread.Sleep(500);
                var card = Deck.Draw();
                if (!(card is LocationCard))
                {
                    LimboPile.Add(card);
                }
                else
                {
                    Hand.Add(card as LocationCard);
                }

                Print();
            } while (Hand.CardCount < 5);

            if (LimboPile.CardCount > 0)
            {
                WaitForShuffle();
            }
        }

        private void DrawUp()
        {
            Print();

            while(Hand.CardCount < 5)
            {
                Thread.Sleep(500);

                var card = Deck.Draw();
                if (card is DreamCard)
                {
                    ResolveDreamCard();
                }
                else if (card is DoorCard)
                {
                    ResolveDoorCard(card as DoorCard);
                }
                else if (card is LocationCard)
                {
                    Hand.Add(card as LocationCard);
                }
                else
                {
                    throw new InvalidOperationException("Card is of unrecognized type");
                }

                Print();
            }

            if (LimboPile.CardCount > 0)
            {
                WaitForShuffle();
            }
        }

        private void ResolveDoorCard(DoorCard doorCard)
        {
            var matchingKey = Hand.Cards.FirstOrDefault(p => p.Suit == LocationSuit.Key && p.Color == doorCard.Color);
            if (matchingKey != null)
            {
                PrintUserOption("Do you want to use a key to open the door? (Y/N)");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    Hand.Remove(matchingKey);
                    DiscardPile.Add(matchingKey);
                    DoorPile.Add(doorCard);
                    return;
                }
            }

            LimboPile.Add(doorCard);
        }

        private void ResolveDreamCard()
        {
            PrintUserOption("NIGHTMARE! Discard (h)and, (d)eck or key(1-5).");
            var resolved = false;
            do
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        resolved = DiscardKey(0);
                        break;
                    case ConsoleKey.D2:
                        resolved = DiscardKey(1);
                        break;
                    case ConsoleKey.D3:
                        resolved = DiscardKey(2);
                        break;
                    case ConsoleKey.D4:
                        resolved = DiscardKey(3);
                        break;
                    case ConsoleKey.D5:
                        resolved = DiscardKey(4);
                        break;
                    case ConsoleKey.H:
                        resolved = DiscardHand();
                        break;
                    case ConsoleKey.D:
                        resolved = DiscardFromDeck(5);
                        break;
                }
            } while (!resolved);
        }

        private bool DiscardFromDeck(int number)
        {
            Deck.Discard(number);
            return true;
        }

        private bool DiscardHand()
        {
            while (Hand.CardCount > 0)
            {
                Discard(0);
            }

            DrawFullHand();

            return true;
        }

        private bool DiscardKey(int index)
        {
            var card = Hand.GetAt(index);
            if (card.Suit == LocationSuit.Key)
            {
                Discard(index);
                return true;
            }

            return false;
        }

        private void WaitForShuffle()
        {
            PrintUserOption("Press any key to shuffle limbo back into deck.");
            Console.ReadKey(true);
            Deck.ShuffleInto(LimboPile);
        }

        private void PrintUserOption(string text)
        {
            Console.SetCursorPosition(1, 13);
            ConsoleUtils.WriteCentered(text);
        }

        private bool CheckGameOver(out bool win)
        {
            win = false;
            if (Deck.IsEmpty())
            {
                return true;
            }

            if (DoorPile.CardCount == 8)
            {
                win = true;
                return true;
            }

            return false;
        }

        private void Print()
        {
            Console.Clear();
            DiscardPile.Print();
            LimboPile.Print();
            DoorPile.Print();
            LocationPile.Print();
            Hand.Print();
            Deck.Print();
        }

        private Deck Deck { get; set; }
        private DiscardPile DiscardPile { get; set; }
        private LocationPile LocationPile { get; set; }
        private LimboPile LimboPile { get; set; }
        private DoorPile DoorPile { get; set; }
        private Hand Hand { get; set; }

        private void ProcessInput()
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    PlayCard(0);
                    break;
                case ConsoleKey.D2:
                    PlayCard(1);
                    break;
                case ConsoleKey.D3:
                    PlayCard(2);
                    break;
                case ConsoleKey.D4:
                    PlayCard(3);
                    break;
                case ConsoleKey.D5:
                    PlayCard(4);
                    break;
                case ConsoleKey.D:
                    PrintUserOption("Discard which card (1-5)?");
                    var cardNumber = GetNumber();
                    if (cardNumber != -1)
                    {
                        DiscardCard(cardNumber);
                    }
                    break;
            }
        }

        private void DiscardCard(int index)
        {
            Discard(index);
            DrawUp();
        }

        private void Discard(int index)
        {
            var card = Hand.RemoveAt(index);
            if (card == null)
            {
                return;
            }

            DiscardPile.Add(card);
        }

        private void PlayCard(int index)
        {
            var card = Hand.GetAt(index);
            if (card == null)
            {
                return;
            }

            var lastPlayedCard = LocationPile.Cards.LastOrDefault();
            if (lastPlayedCard != null && card.Suit == lastPlayedCard.Suit)
            {
                return;
            }

            Hand.RemoveAt(index);
            LocationPile.Add(card);
            
            if (LocationPile.CheckDoorUnlocked())
            {
                var door = Deck.FindDoor(lastPlayedCard.Color);
                if (door != null) DoorPile.Add(door);
                bool win;
                if (CheckGameOver(out win))
                {
                    return;
                }
            }

            DrawUp();
        }

        private int GetNumber()
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return 0;
                case ConsoleKey.D2:
                    return 1;
                case ConsoleKey.D3:
                    return 2;
                case ConsoleKey.D4:
                    return 3;
                case ConsoleKey.D5:
                    return 4;
                default:
                    return -1;
            }
        }
    }
}
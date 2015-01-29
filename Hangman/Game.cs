using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Utils;

namespace Hangman
{
    internal class Game
    {
        private readonly string _word;

        private readonly List<char> _foundChars = new List<char>();

        private const int MaxGuesses = 8;

        private int _wrongGuesses;

        public Game(string word)
        {
            _word = word.ToUpper();
        }

        public void Run()
        {
            for (; ; )
            {
                Print();
                ProcessInput();
                if (CheckGameOver())
                {
                    Console.ReadKey(true);
                    break;
                }
            }
        }

        private bool CheckGameOver()
        {
            if (_wrongGuesses >= MaxGuesses)
            {
                PrintHangman();
                PrintWholeWord();
                Console.SetCursorPosition(0, 1);
                ConsoleUtils.WriteCentered("YOU DIE!");
                return true;
            }

            if (_word.ToCharArray().Distinct().All(p => _foundChars.Contains(p)))
            {
                Console.SetCursorPosition(0, 1);
                ConsoleUtils.WriteCentered("YOU WIN!");
                PrintWord();
                return true;
            }

            return false;
        }

        private void Print()
        {
            Console.Clear();
            PrintHangman();
            PrintWord();
        }

        private void PrintWord()
        {
            var partialSolution = string.Empty;
            foreach (var currentChar in _word.ToCharArray())
            {
                if (_foundChars.Contains(currentChar))
                {
                    partialSolution += currentChar;
                }
                else
                {
                    partialSolution += " ";
                }

                partialSolution += " ";
            }

            Console.SetCursorPosition(0, Constants.Height - 3);
            ConsoleUtils.WriteCentered(partialSolution);

            Console.SetCursorPosition(0, Constants.Height - 2);
            ConsoleUtils.WriteCentered("_ ".Repeat(_word.Length));
        }

        private void PrintWholeWord()
        {
            var solution = _word.ToCharArray()
                .Aggregate(string.Empty, (current, currentChar) => current + (currentChar + " "));

            Console.SetCursorPosition(0, Constants.Height - 3);
            ConsoleUtils.WriteCentered(solution);

            Console.SetCursorPosition(0, Constants.Height - 2);
            ConsoleUtils.WriteCentered("_ ".Repeat(_word.Length));
        }

        private void PrintHangman()
        {
            if (_wrongGuesses <= 0) return;

            var x = (Constants.Width - 25) / 2;
            var y = Constants.Height - 27;
            for (var i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write(Assets.Art[_wrongGuesses - 1][i]);
            }
        }

        private void ProcessInput()
        {
            var key = Console.ReadKey(true);
            var inputChar = char.ToUpper(key.KeyChar);
            if (inputChar < 65 || inputChar > 90 || _foundChars.Contains(inputChar))
            {
                return;
            }

            if (_word.ToCharArray().Contains(inputChar))
            {
                _foundChars.Add(inputChar);
            }
            else
            {
                _wrongGuesses++;
            }
        }
    }
}
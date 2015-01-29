using System;
using Framework.Menus;

namespace Hangman
{
    internal class StartOption : MenuOption
    {
        public override string Text
        {
            get { return "Start"; }
        }

        public override void Execute(params object[] arguments)
        {
            var word = Assets.Words[new Random((int) DateTime.Now.Ticks).Next(0, Assets.Words.Count)];
            new Game(word).Run();
        }

        public override void Left()
        {
        }

        public override void Right()
        {
        }
    }
}
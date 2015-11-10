using Framework.Menus;

namespace Onirim
{
    public class StartOption : MenuOption
    {
        public override string Text
        {
            get { return "Start"; }
        }

        public override void Execute(params object[] arguments)
        {
            new OnirimGame().Run();
        }

        public override void Left()
        {
        }

        public override void Right()
        {
        }
    }
}
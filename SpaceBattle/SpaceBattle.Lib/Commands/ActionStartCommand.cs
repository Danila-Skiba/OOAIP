/*namespace SpaceBattle.Lib
{
    public class ActionStartCommand() : ICommand
    {
        private ICommand _cmd;
        private ISender _sender;
        private IDictionary _game;
        private string _name;

        public ActionStartCommand(ICommand cmd, ISender sender, IDictionary<string, object> obj, string name_event)
        {
            _cmd = cmd;
            _sender = sender;
            _game = obj;
            _name = name_event;
        }

        public void Execute()
        {
            _sender.Send(_cmd);
        }
    }
}*/

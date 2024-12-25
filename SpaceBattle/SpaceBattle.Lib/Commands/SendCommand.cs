namespace SpaceBattle.Lib
{
    public class SendCommand : ICommand
    {
        ICommand _repeatecommand;
        ISender _sender;

        public SendCommand(ICommand cmd, ISender sender)
        {
            _repeatecommand = cmd;
            _sender = sender;
        }

        public void Execute()
        {
            _sender.Send(_repeatecommand);
        }
    }
}
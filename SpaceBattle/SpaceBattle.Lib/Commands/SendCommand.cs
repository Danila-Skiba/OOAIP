namespace SpaceBattle.Lib
{
    public class SendCommand : ICommand
    {
        private readonly ICommand _repeatecommand;
        private readonly ISender _sender;

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

namespace SpaceBattle.Lib;

public class BridgeCommand: IBridgeCommand, ICommand
{
    ICommand _currentCommand;

    public BridgeCommand(ICommand command)
    {
        _currentCommand = command;
    }

    public void Inject(ICommand command)
    {
        _currentCommand = command;
    }

    public void Execute()
    {
        _currentCommand.Execute();
    }
}
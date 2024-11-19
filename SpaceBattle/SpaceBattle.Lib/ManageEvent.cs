namespace SpaceBattle.Lib;

public class ManageEvent
{
    private Queue<ICommand> _commandQueue = new Queue<ICommand>();

    public void Start(ICommand command)
    {
        _commandQueue.Enqueue(command);
    }

    public void End(ICommand command)
    {
        _commandQueue.Dequeue();
    }
}




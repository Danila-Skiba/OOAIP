namespace SpaceBattle.Lib;

public interface IQueue
{
    public void Push(ICommand command);
    public ICommand Take();



}
namespace SpaceBattle.Lib;

public interface IBridgeCommand
{
    void Inject(ICommand command); 
}
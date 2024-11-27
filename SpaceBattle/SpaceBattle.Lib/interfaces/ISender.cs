namespace SpaceBattle.Lib;

public interface ISender{
    void Add(ICommand command);
}
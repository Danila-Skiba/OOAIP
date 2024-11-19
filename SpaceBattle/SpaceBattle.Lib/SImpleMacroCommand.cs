namespace SpaceBattle.Lib;

class SimpleMacroCommand : ICommand
{
    private IEnumerable<ICommand> _cmds;
    public SimpleMacroCommand(IEnumerable<ICommand> cmds)
    {
        _cmds=cmds;
    }

    public void Execute()
    {
        _cmds.ToList().ForEach(i=>i.Execute());
    }
}
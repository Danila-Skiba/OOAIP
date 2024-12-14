using App;
using System;

namespace SpaceBattle.Lib.Commands
{
    public class MacroCommand : ICommand
    {
        private readonly ICommand[] commands;

        public MacroCommand(ICommand[] commands)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }
        public void Execute()
        {
            ExecuteRecursive(0);
        }

        private void ExecuteRecursive(int index)
        {
            if (index >= commands.Length) return;
            commands[index].Execute();
            ExecuteRecursive(index + 1);
        }
    }
}

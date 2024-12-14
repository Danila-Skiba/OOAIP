// SpaceBattle.Lib/Commands/RegisterIoCDependencyMacroCommand.cs
using App;
using System;

namespace SpaceBattle.Lib.Commands
{
    public class RegisterIoCDependencyMacroCommand : ICommand
    {
        public void Execute()
        {
            // Регистрируем "Commands.Macro" через IoC,
            // добавляя проверку на отсутствие аргументов.
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Commands.Macro",
                (object[] args) =>
                {
                    // Если нет аргументов, возвращаем макрокоманду без подкоманд.
                    if (args.Length == 0)
                    {
                        return new MacroCommand(Array.Empty<ICommand>());
                    }

                    // Иначе ожидаем массив команд в args[0].
                    var commands = args[0] as ICommand[];
                    if (commands == null)
                        throw new ArgumentException("Invalid arguments for Commands.Macro");

                    return new MacroCommand(commands);
                }
            ).Execute();
        }
    }
}


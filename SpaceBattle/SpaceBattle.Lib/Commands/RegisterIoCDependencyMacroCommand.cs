using App;

namespace SpaceBattle.Lib.Commands
{
    public class RegisterIoCDependencyMacroCommand : ICommand
    {
        public void Execute()
        {
            //Commands.Macro через IoC добавляя проверку на отсуствие аргументов
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Commands.Macro",
                (object[] args) =>
                {
                    //если нет аргументов возвращаем макрокоманду без подкоманд
                    if (args.Length == 0)
                    {
                        return new MacroCommand(Array.Empty<ICommand>());
                    }

                    if (args[0] is not ICommand[] commands)
                    {
                        throw new ArgumentException("Invalid arguments for Commands.Macro");
                    }

                    return new MacroCommand(commands);
                }
            ).Execute();
        }
    }
}


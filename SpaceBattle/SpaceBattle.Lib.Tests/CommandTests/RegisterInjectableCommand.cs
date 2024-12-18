using App;
using App.Scopes;
using Moq;

namespace SpaceBattle.Lib.Tests
{
    public class RegisterDependencyCommandInjectableCommandTests : IDisposable
    {
        public RegisterDependencyCommandInjectableCommandTests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void RegisterDependencyCommandInjectableCommand_Should_Register_CommandInjectableCommand()
        {

            var registerCommand = new RegisterDependencyCommandInjectableCommand();
            registerCommand.Execute();


            var command = Ioc.Resolve<ICommand>("Commands.CommandInjectable");
            var injectableCommand = Ioc.Resolve<ICommandInjectable>("Commands.CommandInjectable");
            var commandInjectableCommand = Ioc.Resolve<CommandInjectableCommand>("Commands.CommandInjectable");

            Assert.NotNull(command);
            Assert.NotNull(injectableCommand);
            Assert.NotNull(commandInjectableCommand);
        }
        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }
    }
}
using App;
using App.Scopes;
using Moq;

namespace SpaceBattle.Tests
{
    public class RegisterDependencyCommandInjectableCommandTests : IDisposable
    {
        public RegisterDependencyCommandInjectableCommandTests()
        {
            // Инициализация IoC контейнера
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void RegisterDependencyCommandInjectableCommand_Should_Register_CommandInjectableCommand()
        {
            // Создаем мок для ICommand
            var commandMock = new Mock<ICommand>();
            var command = commandMock.Object;

            // Регистрируем ICommand в IoC
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Commands.CommandInjectable",
                (object[] args) => new CommandInjectableCommand()
            ).Execute();

            // Создаем и выполняем команду регистрации
            var registerCommand = new RegisterDependencyCommandInjectableCommand();
            registerCommand.Execute();

            // Проверяем, что зависимости разрешаются без исключений
            var commandInjectable = Ioc.Resolve<ICommandInjectable>("Commands.CommandInjectable");
            var commandInjectableCommand = Ioc.Resolve<CommandInjectableCommand>("Commands.CommandInjectable");

            Assert.NotNull(commandInjectable);
            Assert.NotNull(commandInjectableCommand);
        }

        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }
    }
}
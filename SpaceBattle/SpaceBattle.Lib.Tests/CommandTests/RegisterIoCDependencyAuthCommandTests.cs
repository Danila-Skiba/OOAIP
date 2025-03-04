using App;
using App.Scopes;

namespace SpaceBattle.Lib.Tests
{
    public class RegisterAuthDependenciesTests : IDisposable
    {
        public RegisterAuthDependenciesTests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }

        [Fact]
        public void Execute_RegistersAuthCommand()
        {
            // Arrange
            var registerAuthDependencies = new RegisterAuthDependencies();

            // Act
            registerAuthDependencies.Execute();

            // Assert
            var authCommand = Ioc.Resolve<ICommand>(
                "Commands.Auth",
                "player1", // playerId
                "ship1",   // objectId
                "Fire"     // operation
            );

            Assert.IsType<AuthCommand>(authCommand);
        }

        [Fact]
        public void Execute_ThrowsIfDependencyNotRegistered()
        {
            // Arrange
            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
                Ioc.Resolve<ICommand>(
                    "Commands.Auth",
                    "player1", // playerId
                    "ship1",   // objectId
                    "Fire"     // operation
                )
            );
        }

        [Fact]
        public void Execute_RegistersAndResolvesCorrectly()
        {
            // Arrange
            var registerAuthDependencies = new RegisterAuthDependencies();
            registerAuthDependencies.Execute();

            // Act
            var authCommand = Ioc.Resolve<ICommand>(
                "Commands.Auth",
                "player1", // playerId
                "ship1",   // objectId
                "Fire"     // operation
            );

            // Assert
            Assert.IsType<AuthCommand>(authCommand);
        }
    }
}

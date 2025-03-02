using App;
using Moq;
using App.Scopes;
using Xunit;

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
        public void Execute_ShouldRegisterAuthCommandDependency()
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
        public void Execute_ShouldThrowException_IfDependencyNotRegistered()
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
    }
}
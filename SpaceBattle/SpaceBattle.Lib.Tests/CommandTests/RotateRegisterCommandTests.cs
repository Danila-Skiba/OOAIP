using App;
using App.Scopes;
using Moq;

namespace SpaceBattle.Lib.Tests
{
    public class RegisterIoCDependencyRotateCommandTests : IDisposable
    {

        public RegisterIoCDependencyRotateCommandTests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void Execute_ShouldRegisterRotateCommandDependencyTrue()
        {
            // Arrange
            var rotatingMock = new Mock<IRotating>();
            var mockGameObject = new Mock<object>();
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Adapters.IRotatingObject",
                (object[] args) => rotatingMock.Object
            ).Execute();

            // Act
            var register = new RegisterIoCDependencyRotateCommand();

            register.Execute();

            // Assert
            var resolvedCommand = Ioc.Resolve<ICommand>("Commands.Rotate", mockGameObject.Object);
            Assert.NotNull(resolvedCommand);
            Assert.IsType<Rotate>(resolvedCommand);
        }

        [Fact]
        public void Execute_ShouldNotFindRotateCommandDependencyInNewScope()
        {
            var rotatingMock = new Mock<IRotating>();
            // Act & Assert
            Assert.Throws<Exception>(() => Ioc.Resolve<ICommand>("Commands.Rotate", rotatingMock.Object));
        }

        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }
    }
}

using App;
using App.Scopes;
using Moq;

namespace SpaceBattle.Lib.Tests
{
    public class RegisterIoCDependencyMoveCommandTests
    {
        public RegisterIoCDependencyMoveCommandTests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void Execute_ShouldRegisterMoveCommandDependency()
        {
            var movingMock = new Mock<IMoving>();
            var movingObjectMock = new Mock<object>();

            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Adapters.IMovingObject",
                (object[] args) => movingMock.Object
            ).Execute();

            var register = new RegisterIoCDependencyMoveCommand();
            register.Execute();

            var resolvedCommand = Ioc.Resolve<ICommand>("Commands.Move", movingObjectMock);

            Assert.NotNull(resolvedCommand);
            Assert.IsType<MoveCommand>(resolvedCommand);
        }
    }
}

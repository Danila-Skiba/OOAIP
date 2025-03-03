using Moq;

namespace SpaceBattle.Lib.Tests
{
    public class GameTests
    {

        [Fact]
        public void ExecuteAllCommands()
        {
            var game = new Game();

            var cmd1 = new Mock<ICommand>();
            var cmd2 = new Mock<ICommand>();

            game.Receive(cmd1.Object);
            game.Receive(cmd2.Object);

            game.Execute();

            cmd1.Verify(c => c.Execute(), Times.Once);
            cmd2.Verify(c => c.Execute(), Times.Once);
        }

        [Fact]
        public void ExecuteQueueIsEmpty()
        {
            var game = new Game();

            game.Execute();

            Assert.True(true);
        }

        [Fact]
        public void ExecuteCommandsException()
        {
            var game = new Game();

            var cmd1 = new Mock<ICommand>();
            var cmd2 = new Mock<ICommand>();

            cmd1.Setup(c => c.Execute()).Throws(new Exception());

            game.Receive(cmd1.Object);
            game.Receive(cmd2.Object);

            game.Execute();

            cmd1.Verify(c => c.Execute(), Times.Once);
            cmd2.Verify(c => c.Execute(), Times.Once);
        }
    }
}

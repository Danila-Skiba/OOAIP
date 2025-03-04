using App;
using App.Scopes;

namespace SpaceBattle.Lib.Tests
{
    public class AuthCommandTests : IDisposable
    {
        public AuthCommandTests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
            new RegisterIocDependencyGameRepository().Execute();
        }

        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }

        [Fact]
        public void Execute_PlayerOwnsObjectAndHasPermission_Success()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем объекты и права игрока в репозиторий
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string> { objectId }).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string> { operation }).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act
            var exception = Record.Exception(() => authCommand.Execute());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Execute_PlayerDoesNotOwnObject_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем объекты и права игрока в репозиторий
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string> { "ship2" }).Execute(); // Игрок не владеет ship1
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string> { operation }).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} does not own object {objectId}.", exception.Message);
        }

        [Fact]
        public void Execute_PlayerOwnsObjectButNoPermission_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем объекты и права игрока в репозиторий
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string> { objectId }).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string> { "Move" }).Execute(); // Нет права на "Fire"

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} is not authorized to perform operation '{operation}' on object {objectId}.", exception.Message);
        }

        [Fact]
        public void Execute_PlayerHasNoObjects_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем пустой список объектов игрока в репозиторий
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string>()).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string> { operation }).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} does not own object {objectId}.", exception.Message);
        }

        [Fact]
        public void Execute_ObjectHasNoPermissions_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем объекты игрока в репозиторий, но не добавляем права
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string> { objectId }).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string>()).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} is not authorized to perform operation '{operation}' on object {objectId}.", exception.Message);
        }

        [Fact]
        public void Execute_EmptyObjectList_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем пустой список объектов игрока в репозиторий
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string>()).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string> { operation }).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} does not own object {objectId}.", exception.Message);
        }

        [Fact]
        public void Execute_EmptyPermissionsList_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            // Добавляем объекты игрока в репозиторий, но пустой список прав
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{playerId}_objects", new List<string> { objectId }).Execute();
            Ioc.Resolve<ICommand>("Game.Item.Add", $"{objectId}_permissions", new List<string>()).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} is not authorized to perform operation '{operation}' on object {objectId}.", exception.Message);
        }
    }
}

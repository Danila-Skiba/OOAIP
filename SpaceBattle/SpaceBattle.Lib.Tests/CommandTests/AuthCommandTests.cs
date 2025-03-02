using App;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
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
        }

        [Fact]
        public void Execute_PlayerOwnsObjectAndHasPermission_Success()
        {
            // Arrange
            var playerId = "player1";
            var objectId = "ship1";
            var operation = "Fire";

            var playerObjects = new List<string> { objectId };
            var playerPermissions = new Dictionary<string, List<string>>
            {
                { objectId, new List<string> { operation } }
            };

            // Регистрируем зависимости в IoC
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetObjects",
                (object[] args) => playerObjects
            ).Execute();

            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetPermissions",
                (object[] args) => playerPermissions
            ).Execute();

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

            var playerObjects = new List<string> { "ship2" }; 
            var playerPermissions = new Dictionary<string, List<string>>
            {
                { objectId, new List<string> { operation } }
            };

            // Регистрируем зависимости в IoC
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetObjects",
                (object[] args) => playerObjects
            ).Execute();

            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetPermissions",
                (object[] args) => playerPermissions
            ).Execute();

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

            var playerObjects = new List<string> { objectId };
            var playerPermissions = new Dictionary<string, List<string>>
            {
                { objectId, new List<string> { "Move" } }
            };

            // Регистрируем зависимости в IoC
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetObjects",
                (object[] args) => playerObjects
            ).Execute();

            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Players.GetPermissions",
                (object[] args) => playerPermissions
            ).Execute();

            var authCommand = new AuthCommand(playerId, objectId, operation);

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => authCommand.Execute());
            Assert.Equal($"Player {playerId} is not authorized to perform operation '{operation}' on object {objectId}.", exception.Message);
        }
        public void Dispose()
        {
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Clear").Execute();
        }
    }
}
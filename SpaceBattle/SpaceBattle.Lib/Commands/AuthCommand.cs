using App;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBattle.Lib
{
    public class AuthCommand : ICommand
    {
        private readonly string _playerId;
        private readonly string _objectId;
        private readonly string _operation;

        public AuthCommand(string playerId, string objectId, string operation)
        {
            _playerId = playerId;
            _objectId = objectId;
            _operation = operation;
        }

        public void Execute()
        {
            var playerObjects = Ioc.Resolve<IEnumerable<string>>("Players.GetObjects", _playerId);

            if (!playerObjects.Contains(_objectId))
                throw new UnauthorizedAccessException($"Player {_playerId} does not own object {_objectId}.");

            var playerPermissions = Ioc.Resolve<Dictionary<string, List<string>>>("Players.GetPermissions", _playerId);
            if (!playerPermissions.TryGetValue(_objectId, out var permissions) || !permissions.Contains(_operation))
            {
                throw new UnauthorizedAccessException($"Player {_playerId} is not authorized to perform operation '{_operation}' on object {_objectId}.");
            }
        }
    }
}

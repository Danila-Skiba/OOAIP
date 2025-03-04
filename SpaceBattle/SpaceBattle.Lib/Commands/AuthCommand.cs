using App;

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
            var playerObjects = (List<string>)Ioc.Resolve<object>("Game.Item.Get", $"{_playerId}_objects") ?? new List<string>();
            _ = playerObjects.Contains(_objectId)
                ? true : throw new UnauthorizedAccessException($"Player {_playerId} does not own object {_objectId}.");

            var objectPermissions = (List<string>)Ioc.Resolve<object>("Game.Item.Get", $"{_objectId}_permissions") ?? new List<string>();
            _ = objectPermissions.Contains(_operation)
                ? true : throw new UnauthorizedAccessException($"Player {_playerId} is not authorized to perform operation '{_operation}' on object {_objectId}.");
        }
    }
}

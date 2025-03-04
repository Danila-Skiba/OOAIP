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
            // Получаем объекты игрока через репозиторий
            var playerObjects = (List<string>)Ioc.Resolve<object>("Game.Item.Get", $"{_playerId}_objects") ?? new List<string>();
            if (!playerObjects.Contains(_objectId))
            {
                throw new UnauthorizedAccessException($"Player {_playerId} does not own object {_objectId}.");
            }

            // Получаем права объекта через репозиторий
            var objectPermissions = (List<string>)Ioc.Resolve<object>("Game.Item.Get", $"{_objectId}_permissions") ?? new List<string>();
            if (!objectPermissions.Contains(_operation))
            {
                throw new UnauthorizedAccessException($"Player {_playerId} is not authorized to perform operation '{_operation}' on object {_objectId}.");
            }
        }
    }
}

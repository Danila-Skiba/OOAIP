using App;

namespace SpaceBattle.Lib
{
    public class FireCommand: ICommand
    {
        private readonly IFireable _shooter;
        private readonly IWeapon _weapon;
        private readonly string _weaponId;
        private readonly ICommand _addCommand;

        public FireCommand(IFireable shooter, IWeapon weapon, string weaponId, ICommand addCommand)
        {
            _shooter = shooter;
            _weapon = weapon;
            _weaponId = weaponId;
            _addCommand = addCommand;
        }

        public void Execute()
        {
            _addCommand.Execute();
        }
    }
}

//выстрел
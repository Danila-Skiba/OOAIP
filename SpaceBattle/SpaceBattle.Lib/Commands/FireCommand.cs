using App;

namespace SpaceBattle.Lib
{
    public class FireCommand: ICommand
    {
        private readonly IFireable _shooter;
        private readonly IWeapon _weapon;

        public FireCommand(IFireable shooter, IWeapon _weapon)
        {
            _shooter = shooter;
            _weapon = _weapon;
        }

        public void Execute()
        {
            var weaponId = Guid.NewGuid().ToString();
            Ioc.Resolve<ICommand>("Game.Item.Add", weaponId, _weapon).Execute();
        }
    }
}

//выстрел
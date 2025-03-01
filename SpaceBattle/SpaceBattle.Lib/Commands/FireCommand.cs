using App;

namespace SpaceBattle.Lib
{
    public class FireCommand: ICommand
    {
        private readonly IFireable _shooter;

        public FireCommand(IFireable shooter)
        {
            _shooter = shooter;
        }

        public void Execute()
        {
            var weapon = Ioc.Resolve<IWeapon>("Weapon.Create", _shooter.Position, _shooter.FireDirection);
            var weaponId = Guid.NewGuid().ToString();
            Ioc.Resolve<App.ICommand>("Game.Item.Add", weaponId, weapon).Execute();
        }
    }
}

//выстрел
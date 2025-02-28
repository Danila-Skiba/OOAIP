namespace SpaceBattle.Lib
{
    public class FireCommand: ICommand
    {
        private readonly IFireable _shooter;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IGameObjectRepository _repository;

        public FireCommand(IFireable shooter, IWeaponFactory weaponFactory, IGameObjectRepository repository)
        {
            _shooter = shooter;
            _weaponFactory = weaponFactory;
            _repository = repository;
        }

        public void Execute()
        {
            var weapon = _weaponFactory.CreateWeapon(_shooter.Position, _shooter.FireDirection);
            var weaponId = Guid.NewGuid().ToString();
            _repository.Add(weaponId, weapon);
        }
    }
}

//выстрел
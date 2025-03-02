using App;
namespace SpaceBattle.Lib
{
    public class RegisterFireDependencies: ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Fire", (object[] args) => 
            {
                var shooter = Ioc.Resolve<IFireable>("Adapters.IFireableObject", args[0]);
                var weapon = Ioc.Resolve<IWeapon>("Weapon.Create", shooter.Position, shooter.FireDirection);
                return new FireCommand(shooter, weapon);
            }).Execute();
        }
    }
}

//
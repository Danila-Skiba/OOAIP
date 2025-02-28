using App;
namespace SpaceBattle.Lib
{
    public class RegisterFireDependencies: ICommand
    {
        public boid Execute()
        {
            Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Fire", (object[] args) =>
            new FireCommand(Ioc.Resolve<IFireable>("Adapters.IFireableObject", args[0]),
            Ioc.Resolve<IWeaponFactory>("WeaponFactory"),
            Ioc.Resolve<IGameObjectRepository>("Game.Objects"))).Execute();
        }
    }
}

//
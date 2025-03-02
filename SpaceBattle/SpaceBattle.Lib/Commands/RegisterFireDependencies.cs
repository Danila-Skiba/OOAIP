using App;
namespace SpaceBattle.Lib
{
    public class RegisterFireDependencies: ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Fire", (object[] args) => 
            {
                return new FireCommand((IFireable)args[0], (IWeapon)args[1], (string)args[2], (ICommand)args[3]);
            }).Execute();
        }
    }
}

//
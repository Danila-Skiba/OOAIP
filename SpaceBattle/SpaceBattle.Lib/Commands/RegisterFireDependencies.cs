using App;
namespace SpaceBattle.Lib
{
    public class RegisterFireDependencies: ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Fire", (object[] args) => new FireCommand(
                Ioc.Resolve<IFireable>("Adapters.IFireableObject", args[0])
            )).Execute();
        }
    }
}

//
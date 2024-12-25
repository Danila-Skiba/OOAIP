/*using App;

namespace SpaceBattle.Lib
{
    public class RegisterIoCDependencyActionsStart : ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<App.ICommand>("IoC.Register", "Actions.Start", (object[] args) =>
            {
                var order = (IDictionary<string, object>)args[0];
                var cmd = (ICommand)order["Command"];
                var sender = (ISender)order["Sender"];
                var gameobj = order["Object"];
                
                return new 

            })
        }
    }
}*/

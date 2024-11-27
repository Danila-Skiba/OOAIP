
/*namespace SpaceBattle.Lib;
class StartMoveCommand : ICommand{

    ICommand _command;
    IDictionary _obj;

    ISender _q;
    public StartMoveCommand(ICommand command, IDictionary<string, object> obj, ISender q){
        _command = command;

        _obj = obj;

        _q = q;
    }

    public void Execute(){
        _obj["repeatableMove"]=_command;
        _q.Add(_command);
    }


}*/
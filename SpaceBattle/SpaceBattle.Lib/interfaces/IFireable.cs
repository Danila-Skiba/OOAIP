namespace SpaceBattle.Lib
{
    public interface IFireable
    {
        Vector Position { get; }
        Vector FireDirection { get; }
    }
}

//для объекта способного стрелять
//position - откуда стреляем, FireDirection - направление выстрела(скорость)


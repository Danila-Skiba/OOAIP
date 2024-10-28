namespace SpaceBattle.Lib;

public interface IMoving
{
    Vector Position { get; set; }
    Vector Velocity { get; }
}

public interface ICommand
{
    public void Execute();
}

public class Move : ICommand
{
    private readonly IMoving moving;
    public Move(IMoving moving)
    {
        this.moving = moving;
    }
    public void Execute()
    {
        moving.Position = new Vector(moving.Position.X + moving.Velocity.X, moving.Position.Y + moving.Velocity.Y);

        /*moving.Position = new int[]{
            moving.Position[0]+moving.Velocity[0],
            moving.Position[1]+moving.Velocity[1],
       };*/
    }
}

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
}
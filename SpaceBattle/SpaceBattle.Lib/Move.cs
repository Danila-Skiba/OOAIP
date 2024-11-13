namespace SpaceBattle.Lib;

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
    }
}
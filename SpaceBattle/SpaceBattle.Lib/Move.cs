using SpaceBattle.Lib;

namespace SpaceBattle.Lib
{
    public interface IMoving
    {
        Vector Position { get; set; }
        Vector Velocity { get; }
    }

    public interface ICommand
    {
        public void Execute();
    }

    public class MoveCommand : ICommand
    {
        private readonly IMoving moving;
        public MoveCommand(IMoving moving)
        {
            this.moving = moving;
        }
        public void Execute()
        {
            moving.Position += moving.Velocity;
        }
    }
}
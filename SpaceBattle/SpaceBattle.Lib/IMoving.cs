using SpaceBattle.Lib;
namespace SpaceBattle.Lib
{
    public interface IMoving
    {
        Vector Position { get; set; }
        Vector Velocity { get; }
    }
}
namespace SpaceBattle.Lib;
using SpaceBattle.Lib;
public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x; 
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector vector) 
        {
            return this.X == vector.X && this.Y == vector.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}


namespace SpaceBattle.Lib;
using SpaceBattle.Lib;
public class Vector
{
    private readonly int[] coordinates;

    public Vector(int[] coord)
    {
        coordinates = coord;
    }

    public int[] GetCoordinates()
    {
        return (int[])coordinates.Clone();
    }

    public override bool Equals(object? obj)
    {
    
        if (obj is Vector vector && vector.coordinates.Length == this.coordinates.Length) 
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (this.coordinates[i] != vector.coordinates[i]) return false;
            }
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return System.HashCode.Combine(coordinates);
    }

    public static Vector operator +(Vector vector1, Vector vector2)
    {
        if (vector1.coordinates.Length != vector2.coordinates.Length)
        {
            throw new ArgumentException("Вектора должны иметь одинаковую размерность");
        }

        int[] result = new int[vector1.coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = vector1.coordinates[i] + vector2.coordinates[i];
        }

        return new Vector(result);
    }

    public static bool operator ==(Vector vector1, Vector vector2)
    {
        return vector1.Equals(vector2);
    }

    public static bool operator !=(Vector vector1, Vector vector2)
    {
        return !(vector1 == vector2);
    }
}


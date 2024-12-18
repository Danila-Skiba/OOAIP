﻿public class Angle
{
    private static readonly int d = 8;
    private readonly int n;

    public Angle(int n)
    {
        this.n = n % d;
    }

    public static Angle operator +(Angle u1, Angle u2)
    {
        return new Angle((u1.n + u2.n) % d);
    }

    public static bool operator ==(Angle u1, Angle u2)
    {
        return u1.Equals(u2);
    }

    public static bool operator !=(Angle u1, Angle u2)
    {
        return !u1.Equals(u2);
    }

    private double ToRadians()
    {
        double degrees = n * 360 / d;
        return degrees * Math.PI / 180.0;
    }

    public double Sin()
    {
        return Math.Sin(ToRadians());
    }

    public double Cos()
    {
        return Math.Cos(ToRadians());
    }

    public override bool Equals(object? obj)
    {

        if (obj is Angle angle)
        {
            return n == angle.n;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return n.GetHashCode();
    }
}

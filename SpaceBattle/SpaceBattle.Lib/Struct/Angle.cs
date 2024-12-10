public class Angle
{

    static readonly int d = 8;

    int n;

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

    public override bool Equals(object? obj)
    {

        if (obj is Angle angle)
        {
            return this.n == angle.n;
        }
        else { return false; }
    }

    public override int GetHashCode()
    {
        return n.GetHashCode();
    }
}
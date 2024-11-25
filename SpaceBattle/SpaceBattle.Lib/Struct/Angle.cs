public class Angle
{
    public int A { get; set; }

    public Angle(int a)
    {
        A = a % 360;
    }

    public static Angle operator +(Angle u1, Angle u2)
    {
        return new Angle(u1.A + u2.A);
    }

    public override bool Equals(object? obj)
    {

        if (obj is Angle angle)
        {
            return this.A == angle.A;
        }

        else{return false;}

        
    }

    public override int GetHashCode()
    {
            return HashCode.Combine(A);
    }
}
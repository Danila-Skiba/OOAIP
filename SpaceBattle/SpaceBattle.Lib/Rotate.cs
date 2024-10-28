namespace SpaceBattle.Lib;


public interface IRotating
{
    double Current_Angle { get; set; }

    double Angle_Velocity { get; }
}

public class Rotate : ICommand
{
    private readonly IRotating rotating;

    public Rotate(IRotating rotating)
    {
        this.rotating = rotating;
    }

    public void Execute()
    {
        rotating.Current_Angle += rotating.Angle_Velocity;
    }

}


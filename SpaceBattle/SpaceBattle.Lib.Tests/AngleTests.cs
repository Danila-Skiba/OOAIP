using Moq;
using SpaceBattle.Lib;
namespace SpaceBattle.Lib.Tests;

public class TestsAngle
{
    [Fact]
    public void AngleEqualsTestUnCorrectAngle(){
        var angle1 = new Angle(45);

        var angle2 = 45;

    Assert.False(angle1.Equals(angle2));
    }
    [Fact]
    public void AngleEqualsTestCorrectAngleTrue()
    {
        var angle1 = new Angle(45);

        var angle2 = new Angle(45);

        Assert.True(angle1.Equals(angle2));
    }
    [Fact]
    public void AngleEqualsTestCorrectAngleFalse(){

        var angle1 = new Angle(45);
        var angle2 = new Angle(90);

        Assert.False(angle1.Equals(angle2));
    }

    [Fact]
    public void Angle_Addition_True()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(45);

        var sum_angle_current = angle1+angle2;
        var sum_angle_expected = new Angle(75);

        Assert.True(sum_angle_current.Equals(sum_angle_expected));
    }
    
    [Fact]
    public void Angle_Addition_Over360_True()
    {
        var angle1 = new Angle(300);
        var angle2 = new Angle(100);

        var sum_angle_current = angle1+angle2;

        var sum_angle_expected = new Angle(400);

        Assert.True(sum_angle_current.Equals(sum_angle_expected));
    }

    [Fact]
    public void Angle_GetHashCode_SameAngles()
    {
        var angle1 = new Angle(90);
        var angle2 = new Angle(90);

        Assert.Equal(angle1.GetHashCode(),angle2.GetHashCode());
    }

    [Fact]
    public void Angle_GetHashCode_DifferentAngles()
    {
        var angle1 = new Angle(90);
        var angle2 = new Angle(180);

        Assert.NotEqual(angle1.GetHashCode(),angle2.GetHashCode());
    }
    [Fact]
    public void Angle_Equals_Null_ReturnsFalse()
    {
        var angle1 = new Angle(90);
        Assert.False(angle1.Equals(null));
    }
}
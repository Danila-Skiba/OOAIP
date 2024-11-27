using Moq;
using SpaceBattle.Lib;
namespace SpaceBattle.Lib.Tests;
public class TestsMoveCommand
{
    [Fact]
    public void MoveTest()
    {
        var moving = new Mock<IMoving>();

        moving.SetupGet(m => m.Position).Returns(new Vector(12, 5));
        moving.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

        var move_cmd = new Move(moving.Object);
        move_cmd.Execute();


        moving.VerifySet(m => m.Position = new Vector(5, 8));
    }

    [Fact]
    public void Move_CantReadPosition()
    {

        var moving = new Mock<IMoving>();
        moving.SetupGet(m => m.Position).Throws<Exception>();
        moving.SetupGet(m => m.Velocity).Returns(new Vector(1, 1));


        Assert.Throws<Exception>(() => new Move(moving.Object).Execute());
    }

    [Fact]

    public void Move_CantReadVelocity()
    {
        var moving = new Mock<IMoving>();
        moving.SetupGet(m => m.Position).Returns(new Vector(1, 1));
        moving.SetupGet(m => m.Velocity).Throws<Exception>();


        Assert.Throws<Exception>(() => new Move(moving.Object).Execute());
    }

    [Fact]
    public void Move_CantWritePosition()
    {
        // Arrange
        var moving = new Mock<IMoving>();
        moving.SetupGet(m => m.Position).Returns(new Vector(1, 1));
        moving.SetupGet(m => m.Velocity).Returns(new Vector(1, 1));
        moving.SetupSet(m => m.Position = new Vector(2, 2)).Throws<Exception>();

        // Act & Assert
        Assert.Throws<Exception>(() => new Move(moving.Object).Execute());
    }

}
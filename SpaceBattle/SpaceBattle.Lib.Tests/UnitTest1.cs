using Moq;
using SpaceBattle.Lib;

namespace SpaceBattle.Lib.Tests;
public class Tests
{
    [Fact]
    public void TestPostitive()
    {
        // AAA
        // Arrange
        //1. Создать движущийся объект
        var moving = new Mock<IMoving>();

        //2. Движущемуся объекту присвоить позицию и скорость
        moving.SetupGet(m => m.Position).Returns(new Vector(12, 5));
        moving.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

        // Act
        // Вызвать команду движения
        var cmd = new Move(moving.Object);
        cmd.Execute();

        // Assert
        // Проверить, что объект находится в ожидаемой позиции
        moving.VerifySet(m => m.Position = new Vector(5, 8));
    }
}
/*[Fact]
public void TestPositionRaisesException()
{
    // G
    var moving = new Mock<IMoving>();
    moving.SetupGet(m => m.Position).Throws<Exception>();
    moving.SetupGet(m => m.Velocity).Returns(new Vector(1, 1));
    // When
    var cmd = new Move(moving.Object);
    // Then

    Assert.Throws<Exception>(
        () => cmd.Execute()
    );
}

[Fact]

public void TestVelocityRaisesEception()
{
    var moving = new Mock<IMoving>();
    moving.SetupGet(m => m.Position).Returns(new Vector(1, 1));
    moving.SetupGet(m => m.Velocity).Throws<Exception>();

    var cmd = new Move(moving.Object);

    Assert.Throws<Exception>(
        () => cmd.Execute()
    );
}*/

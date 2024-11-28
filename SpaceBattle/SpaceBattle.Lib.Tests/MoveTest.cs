using System;
using Moq;
using Xunit;

using SpaceBattle.Lib;
namespace SpaceBattle.Lib.Tests
{
    public class MoveTest
    {
        [Fact]
        public void TestObjectMove()
        {
            var obj_moving = new Mock<IMoving>();

            obj_moving.SetupGet(a => a.Position).Returns(new Vector (new int[] {12, 5}));
            obj_moving.SetupGet(a => a.Velocity).Returns(new Vector (new int[] {-7, 3}));

            var command = new MoveCommand(obj_moving.Object);
            command.Execute();

            obj_moving.VerifySet(a => a.Position = new Vector (new int[] {5, 8}));
        }


        [Fact]
        public void TestPositionObjectCannotRead()
        {
            var obj_moving = new Mock<IMoving>();
            obj_moving.SetupGet(a => a.Position).Throws(new InvalidOperationException("Нельзя прочитать положение объекта"));

            var command = new MoveCommand(obj_moving.Object);

            var exception = Assert.Throws<InvalidOperationException>(() => command.Execute());
            Assert.Equal("Нельзя прочитать положение объекта", exception.Message);
        }

        [Fact]
        public void TestVelocityObjectCannotRead()
        {
            var obj_moving = new Mock<IMoving>();

            obj_moving.SetupGet(a => a.Position).Returns(new Vector(new int[] {12, 5}));
            obj_moving.SetupGet(a => a.Velocity).Throws(new InvalidOperationException("Нельзя прочитать скорость объекта"));
            
            var command = new MoveCommand(obj_moving.Object);
            
            var exception = Assert.Throws<InvalidOperationException>(() => command.Execute());
            Assert.Equal("Нельзя прочитать скорость объекта", exception.Message);
        }

        [Fact]
        public void TestImpossibleChangePositionObject()
        {
            var obj_moving = new Mock<IMoving>();

            obj_moving.SetupGet(a => a.Position).Returns(new Vector (new int[] {12, 5}));
            obj_moving.SetupGet(a => a.Velocity).Returns(new Vector (new int[] {-7, 3}));

            obj_moving.SetupSet(a => a.Position = new Vector(new int[] {5, 8})).Throws(new InvalidOperationException("Нельзя изменить положение объекта"));

            var command = new MoveCommand(obj_moving.Object);

            var exception = Assert.Throws<InvalidOperationException>(() => command.Execute());
            Assert.Equal("Нельзя изменить положение объекта", exception.Message);
        }
    
    }    

}

using Moq;
using SpaceBattle.Lib;
namespace SpaceBattle.Lib.Tests;


public class TestVector(){

    [Fact]
    public void TestEqualsSize()
    {
        Assert.Throws<ArgumentException>(() => new Vector(1, 2, 3));
    }
}
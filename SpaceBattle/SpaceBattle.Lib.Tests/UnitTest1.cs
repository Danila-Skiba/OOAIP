using Xunit;

namespace SpaceBattle.Lib.Tests
{
    public class SomeClassTests
    {
        [Fact]
        public void CalculateDamage_PositiveDamage()
        {
            var someClass = new SomeClass();
            var damage = someClass.CalculateDamage(10, 5);
            Assert.Equal(5, damage);
        }

        [Fact]
        public void CalculateDamage_ZeroDamage()
        {
            var someClass = new SomeClass();
            var damage = someClass.CalculateDamage(5, 10);
            Assert.Equal(0, damage);
        }
    }
}

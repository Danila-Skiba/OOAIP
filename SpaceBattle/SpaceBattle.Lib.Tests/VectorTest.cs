using System;
using Xunit;
using SpaceBattle.Lib;

namespace SpaceBattle.Lib.Tests
{
    public class VectorTests
    {
        [Fact]
        public void TestEqualityOfVectors()
        {
            var vector1 = new Vector(new int[]{1,2});
            var vector2 = new Vector(new int[]{1,2});

            Assert.Equal(vector1, vector2);
        }

        [Fact]
        public void TestInequalityOfVectros()
        {
            var vector1 = new Vector(new int[]{1,2});
            var vector2 = new Vector(new int[]{3,2});

            Assert.NotEqual(vector1, vector2);
        }

        [Fact]
        public void TestAddingVectors()
        {
            var vector1 = new Vector(new int[]{7,3});
            var vector2 = new Vector(new int[]{0,4});

            var sum = vector1 + vector2;

            Assert.Equal(new Vector(new int[]{7,7}), sum);
        }

        [Fact]
        public void TestAddingNullVectors()
        {
            var vector1 = new Vector(new int[]{1,2});
            Vector? vector2 = null;

            Assert.Throws<ArgumentNullException>(() => { var sum = vector1 + vector2; });
        }

        [Fact]
        public void TestEqualityOneNullVectors()
        {
            var vector1 = new Vector(new int[]{1,2});
            Vector? vector2 = null;

            Assert.False(vector1 == vector2);
        }

        [Fact]
        public void TestEqualityTwoNullVectors()
        {
            Vector? vector1 = null;
            Vector? vector2 = null;

            Assert.True(vector1 == vector2);
        }

        [Fact]
        public void TestAnotherTypeAndVector()
        {
            var vector1 = new Vector(new int[]{1,2});
            var vector2 = "str";

            Assert.False(vector1.Equals(vector2));
        } 

        [Fact]
        public void TestAddVectorsDifferentDimensions()
        {
            var vector1 = new Vector(new int[]{1,2});
            var vector2 = new Vector(new int[]{1,2,3});

            var exception = Assert.Throws<ArgumentException>(() => { var sum = vector1 + vector2; });

            Assert.Equal("Вектора должны иметь одинаковую размерность", exception.Message);
        }

        [Fact]
        public void TestGetCoordinates()
        {
            var coord = new int[] {1,2};
            var vector = new Vector(coord);

            var copyCoord = vector.GetCoordinates();
            copyCoord[1] = 5;

            Assert.Equal(new int[] {1,2}, vector.GetCoordinates());
        }

        [Fact]
        public void TestHashCode()
        {
            var coordinates = new int[] { 1, 2 };
            var vector1 = new Vector(coordinates);
            var vector2 = new Vector(coordinates);

            Assert.Equal(vector1.GetHashCode(), vector2.GetHashCode());
        }

        
    }
}
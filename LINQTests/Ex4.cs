using System.Collections.Generic;
using Xunit;
using LINQ;
using System.Linq;

namespace LINQTests
{
    public class Ex4
    {
        [Fact]
        public void LinqTest_ShouldReturnCorrectPairs()
        {
            // Arrange
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            int target = 6;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Equal(2, pairs.Count());
            Assert.Contains((1, 5), pairs);
            Assert.Contains((2, 4), pairs);
        }

        [Fact]
        public void LinqTest_WhenNotInOrder_ShouldReturnCorrectPairs()
        {
            // Arrange
            List<int> numbers = new List<int>() { 5, 1, 3, 2, 4 };
            int target = 6;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Equal(2, pairs.Count());
            Assert.Contains((1, 5), pairs);
            Assert.Contains((2, 4), pairs);
        }

        [Fact]
        public void LinqTest_WhenDuplicateElements_ShouldReturnCorrectPairs()
        {
            // Arrange
            List<int> numbers = new List<int>() { 1, 2, 3, 3, 4, 5 };
            int target = 6;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Equal(3, pairs.Count());
            Assert.Contains((1, 5), pairs);
            Assert.Contains((2, 4), pairs);
            Assert.Contains((3, 3), pairs);
        }

        [Fact]
        public void LinqTest_ShouldReturnEmptyList_WhenTargetIsNotReached()
        {
            // Arrange
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            int target = 19;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Empty(pairs);
        }

        [Fact]
        public void LinqTest_ShouldReturnCorrectPairs_WhenAllNumbersAreNegative()
        {
            // Arrange
            List<int> numbers = new List<int>() { -5, -4, -3, -2, -1 };
            int target = -6;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Equal(2, pairs.Count());
            Assert.Contains((-5, -1), pairs);
            Assert.Contains((-4, -2), pairs);
        }

        [Fact]
        public void LinqTest_ShouldReturnCorrectPairs_WhenNumbersAreMixed()
        {
            // Arrange
            List<int> numbers = new List<int>() { -1, 2, 3, -4, 5 };
            int target = 4;

            // Act
            var pairs = numbers.Ex4(target);

            // Assert
            Assert.Single(pairs);
            Assert.Contains((-1, 5), pairs);
        }
    }
}
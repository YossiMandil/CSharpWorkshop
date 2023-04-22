using System.Collections.Generic;
using Xunit;
using LINQ;

namespace LINQTests
{
    public class Ex3
    {
        [Fact]
        public void TestSecondSmallest()
        {
            var numbers = new List<int> { 5, 1, 3, 2, 4 };
            var secondSmallest = numbers.Ex3();
            Assert.Equal(2, secondSmallest);
        }

        [Fact]
        public void TestSecondSmallestWithDuplicates()
        {
            var numbers = new List<int> { 5, 1, 3, 2, 2, 4 };
            var secondSmallest = numbers.Ex3();
            Assert.Equal(2, secondSmallest);
        }

        [Fact]
        public void TestSecondSmallestWithNegativeNumbers()
        {
            var numbers = new List<int> { -5, -1, -3, -2, -4 };
            var secondSmallest = numbers.Ex3();
            Assert.Equal(-4, secondSmallest);
        }
    }
}
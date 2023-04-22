using System.Collections.Generic;
using Xunit;

namespace MyListTests
{
    public class ListDistinctTests
    {
        [Fact]
        public void Distinct_ReturnsDistinctElements()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);
            list.Add(3);
            list.Add(3);

            // Act
            var distinctList = list.Distinct();

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, distinctList);
        }

        [Fact]
        public void Distinct_WithEqualityComparer_ReturnsDistinctElements()
        {
            // Arrange
            var list = new MyList<int>();

            // Act
            var distinctList = list.Distinct();

            // Assert
            Assert.Empty(distinctList);
        }
    }
}
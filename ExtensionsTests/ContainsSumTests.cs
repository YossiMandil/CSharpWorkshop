using System.Collections.Generic;
using Xunit;

namespace ExtensionMethodsTests
{
    public class ContainsSumTests
    {
        [Fact]
        public void ContainsSum_ReturnsTrue_WhenListContainsTwoElementsWhoseSumIsEqualToTargetSum()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int targetSum = 7;

            // Act
            bool result = list.ContainsSum(targetSum);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ContainsSum_ReturnsFalse_WhenListDoesNotContainTwoElementsWhoseSumIsEqualToTargetSum()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int targetSum = 10;

            // Act
            bool result = list.ContainsSum(targetSum);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ContainsSum_ReturnsFalse_WhenListIsEmpty()
        {
            // Arrange
            List<int> list = new List<int>();
            int targetSum = 0;

            // Act
            bool result = list.ContainsSum(targetSum);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ContainsSum_ReturnsFalse_WhenListContainsOnlyOneElement()
        {
            // Arrange
            List<int> list = new List<int> { 1 };
            int targetSum = 0;

            // Act
            bool result = list.ContainsSum(targetSum);

            // Assert
            Assert.False(result);
        }
    }
}

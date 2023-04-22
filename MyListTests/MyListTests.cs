using System;
using Xunit;

namespace MyListTests
{
    public class MyListTests
    {
        [Fact]
        public void Add_AddsItemToList()
        {
            // Arrange
            MyList<int> list = new MyList<int>();

            // Act
            list.Add(1);
            list.Add(2);

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void Remove_RemovesItemFromList()
        {
            // Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            bool result = list.Remove(2);

            // Assert
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(3, list[1]);
        }

        [Fact]
        public void Remove_ReturnsFalseIfItemNotFound()
        {
            // Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            // Act
            bool result = list.Remove(3);

            // Assert
            Assert.False(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void Indexer_GetItem_ReturnsCorrectValue()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            int itemAtIndex1 = list[1];

            // Assert
            Assert.Equal(2, itemAtIndex1);
        }

        [Fact]
        public void Indexer_SetItem_ModifiesList()
        {
            // Arrange
            var list = new MyList<string>();
            list.Add("hello");
            list.Add("world");
            list.Add("!");

            // Act
            list[1] = "C#";
            string itemAtIndex1 = list[1];

            // Assert
            Assert.Equal("C#", itemAtIndex1);
            Assert.Equal(3, list.Count);
            Assert.Equal("hello", list[0]);
            Assert.Equal("C#", list[1]);
            Assert.Equal("!", list[2]);
        }

        [Fact]
        public void Indexer_GetItem_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var list = new MyList<double>();
            list.Add(3.14);
            list.Add(2.71);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                double itemAtIndex2 = list[2];
            });
        }

        [Fact]
        public void Indexer_SetItem_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var list = new MyList<DateTime>();
            list.Add(DateTime.Today);
            list.Add(DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                list[2] = DateTime.UtcNow;
            });
        }
    }
}
using System;
using System.Collections.Generic;
using Xunit;

namespace MyListTests
{
    public class IEnumerableTests
    {
        [Fact]
        public void ReturnsAllElements()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            int count = 0;

            // Assert
            var expectedList = new List<int> { 1, 2, 2, 3, 4, 5 };
            int i = 0;

            foreach (var item in list)
            {
                count++;
                Assert.Equal(expectedList[i++], item);
            }

            Assert.Equal(6, count);
        }

        [Fact]
        public void ReturnsAllElements_DoubleEnumeration()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            int count = 0;

            // Assert
            var expectedList = new List<int> { 1, 2, 2, 3, 4, 5 };
            int i = 0;

            foreach (var item in list)
            {
                count++;
                Assert.Equal(expectedList[i++], item);
            }

            Assert.Equal(6, count);

            i = 0;
            count = 0;
            foreach (var item in list)
            {
                count++;
                Assert.Equal(expectedList[i++], item);
            }

            Assert.Equal(6, count);
        }

        [Fact]
        public void GetEnumerator_EmptyList()
        {
            // Arrange
            var list = new MyList<int>();

            // Act
            var enumerator = list.GetEnumerator();

            // Assert
            foreach (var _ in list)
            {
                Assert.False(true);
            }

            enumerator.Reset();
            foreach (var _ in list)
            {
                Assert.False(true);
            }
        }

        [Fact]
        public void GetEnumerator_ResetWorks()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            int count = 0;

            // Act
            var enumerator = list.GetEnumerator();

            // Assert

            var expectedList = new List<int> { 1, 2, 2, 3, 4, 5 };
            int i = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.Equal(expectedList[i++], enumerator.Current);
            }

            Assert.Equal(6, count);

            enumerator.Reset();
            i = 0;
            count = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.Equal(expectedList[i++], enumerator.Current);
            }

            Assert.Equal(6, count);
        }
    }

}
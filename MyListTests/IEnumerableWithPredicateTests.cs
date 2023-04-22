using System;
using System.Collections.Generic;
using Xunit;

namespace MyListTests
{
    public class IEnumerableWithPredicateTests
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


            Func<int, bool> isEvenPredicate = x => x % 2 == 0;
            int count = 0;

            // Act
            var enumerator = list.GetEnumerator(isEvenPredicate);

            // Assert
            var expectedList = new List<int> { 2, 2, 4 };
            int i = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.Equal(expectedList[i++], enumerator.Current);
            }

           Assert.Equal(3,count);
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

            Func<int, bool> isEvenPredicate = x => x % 2 == 0;
            int count = 0;

            // Act
            var enumerator = list.GetEnumerator(isEvenPredicate);

            // Assert
            var expectedList = new List<int> { 2, 2, 4 };
            int i = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.Equal(expectedList[i++], enumerator.Current);
            }

            Assert.Equal(3, count);

            enumerator.Reset();
            i = 0;
            count = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.Equal(expectedList[i++], enumerator.Current);
            }

            Assert.Equal(3, count);
        }

        [Fact]
        public void GetEnumerator_EmptyList()
        {
            // Arrange
            var list = new MyList<int>();
            Func<int, bool> isEvenPredicate = x => x % 2 == 0;

            // Act
            var enumerator = list.GetEnumerator(isEvenPredicate);

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
    }
}
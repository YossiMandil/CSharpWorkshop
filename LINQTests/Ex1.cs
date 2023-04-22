using System;
using System.Collections.Generic;
using Xunit;

namespace LINQTests
{
    public class Ex1
    {
        [Fact]
        public void ReturnsNamesOfPeopleBetween18And30SortedAlphabetically()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person("John", new DateTime(1995, 5, 15) ),
                new Person("Mary", new DateTime(2005, 9, 20)),
                new Person ("Bob",new DateTime(1996, 1, 1)),
                new Person("Alice", new DateTime(1980, 12, 31))
            };
            var expectedNames = new List<string> { "Bob", "John" };

            // Act
            IEnumerable<string> names = people.Ex1();

            // Assert
            Assert.Equal(expectedNames, names);
        }

        [Fact]
        public void ReturnsEmptyListIfNoPeopleBetween18And30()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person("John", new DateTime(2005, 5, 15)),
                new Person("Mary",new DateTime(2010, 9, 20)),
                new Person("Bob", new DateTime(1980, 1, 1) ),
                new Person("Alice", new DateTime(1970, 12, 31))
            };
            var expectedNames = new List<string>();

            // Act
            var names = people.Ex1();

            // Assert
            Assert.Equal(expectedNames, names);
        }
    }
}
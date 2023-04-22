using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace LINQTests
{
    public class Ex2
    {
        [Fact]
        public void Ex2_ReturnsEmptyDictionary_ForEmptyList()
        {
            // Arrange
            var people = new List<Person>();

            // Act
            var result = people.Ex2();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Ex2_ReturnsCorrectDictionary()
        {
            // Arrange
            var people = new List<Person>()
        {
            new Person("John", new DateTime(1985, 4, 15)),
            new Person("Jane", new DateTime(1990, 7, 1)),
            new Person("Bob", new DateTime(1987, 12, 25)),
            new Person("Alice", new DateTime(1995, 9, 10)),
            new Person("David", new DateTime(1985, 8, 30)),
            new Person("Carol", new DateTime(1992, 2, 12))
        };

            // Act
            var result = people.Ex2();

            // Assert
            Assert.Equal(5, result.Count);

            Assert.True(result.ContainsKey(1985));
            Assert.Equal(2, result[1985].Count);
            Assert.Contains(people[0], result[1985]);
            Assert.Contains(people[4], result[1985]);

            Assert.True(result.ContainsKey(1990));
            Assert.Single(result[1990]);
            Assert.Contains(people[1], result[1990]);

            Assert.True(result.ContainsKey(1992));
            Assert.Single(result[1992]);
            Assert.Contains(people[5], result[1992]);
        }
    }
}
using Inheritance;
using Inheritance.Ex1;
using Inheritance.Ex2;
using Inheritance.Ex3;
using System.Linq;
using Xunit;

namespace Tests
{
    public class InheritanceTests
    {
        [Fact]
        public void Ex1()
        {
            var actualAsLower = Answers.Ex1_GetAnswer.Select(x => char.ToLower(x));
            var expectedAsLower = Ex1Runner.Run().Select(x => char.ToLower(x));

            Assert.True(expectedAsLower.SequenceEqual(actualAsLower));
        }

        [Fact]
        public void Ex2()
        {
            var actualAsLower = Answers.Ex2_GetAnswer.Select(x => char.ToLower(x));
            var expectedAsLower = Ex2Runner.Run().Select(x => char.ToLower(x));

            Assert.True(expectedAsLower.SequenceEqual(actualAsLower));
        }

        [Fact]
        public void Ex3()
        {
            var actualAsLower = Answers.Ex3_GetAnswer.Select(x => char.ToLower(x));
            var expectedAsLower = Ex3Runner.Run().Select(x => char.ToLower(x));

            Assert.True(expectedAsLower.SequenceEqual(actualAsLower));
        }
    }
}
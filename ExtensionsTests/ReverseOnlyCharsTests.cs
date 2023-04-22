using Xunit;

namespace ExtensionMethodsTests
{
    public class ReverseOnlyCharsTests
    {
        [Fact]
        public void Test1()
        {
            var input = "ab-cd-ef";
            var expected = "fe-dc-ba";
            var actual = input.ReverseOnlyChars();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            var input = "abcdef";
            var expected = "fedcba";
            var actual = input.ReverseOnlyChars();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3()
        {
            var input = "-**cd-ef*t*";
            var expected = "-**tf-ed*c*";
            var actual = input.ReverseOnlyChars();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {
            var input = string.Empty;
            var expected = string.Empty;
            var actual = input.ReverseOnlyChars();

            Assert.Equal(expected, actual);
        }
    }
}
using System;
using Xunit;

namespace Project.Test
{
    public class KataCalculatorTests
    {
        private readonly KataCalculator _calculator;

        public KataCalculatorTests()
        {
            _calculator = new KataCalculator();
        }

        [Fact]
        public void Empty_String_Returns_Zero()
        {
            Assert.Equal(0, _calculator.add(""));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("5", 5)]
        public void One_Number_String_Returns_Number_Itself(string input, int expected)
        {
            Assert.Equal(expected, _calculator.add(input));
        }

        [Theory]
        [InlineData("3,4", 7)]
        [InlineData("2,8", 10)]
        public void Two_Numbers_String_Returns_Sum(string input, int expected)
        {
            Assert.Equal(expected, _calculator.add(input));
        }

        [Theory]
        [InlineData("3,4,3", 10)]
        [InlineData("1,2,3,4", 10)]
        public void Multiple_Numbers_String_Returns_Sum(string input, int expected)
        {
            Assert.Equal(expected, _calculator.add(input));
        }

        [Theory]
        [InlineData("3\n2,3", 8)]
        [InlineData("1\n2,3", 6)]
        public void NewLines_Between_Numbers_String_ReturnsSum(string input, int expected)
        {
            Assert.Equal(expected, _calculator.add(input));
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//|\n2|3|4", 9)]
        public void Multiple_Delimiters_Between_Numbers_Returns_Sum(string input, int expected)
        {
            Assert.Equal(expected, _calculator.add(input));
        }

        [Fact]
        public void Negative_Numbers_Throw_Exception()
        {
            var ex = Assert.Throws<Exception>(() => _calculator.add("-4"));
            Assert.Equal("Negatives Not allowed: -4", ex.Message);
        }

        [Fact]
        public void Multiple_Negative_Numbers_Throw_Exception()
        {
            var ex = Assert.Throws<Exception>(() => _calculator.add("-1,-3"));
            Assert.Equal("Negatives Not allowed: -1,-3", ex.Message);
        }
    }
}
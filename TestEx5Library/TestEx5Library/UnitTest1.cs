using System;
using Xunit;

namespace ExerciseFive.Tests
{
    public class PersonaHelperTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(17, 0)]
        [InlineData(18, 1)]
        [InlineData(65, 1)]
        [InlineData(66, 2)]
        [InlineData(120, 2)]
        public void ClassifyAge_ShouldReturnExpectedResult(int age, int expected)
        {
            // Create a new instance of PersonaHelper within the method
            PersonaHelper helper = new PersonaHelper();
            int result = helper.ClassifyAge(age);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(17, false)]
        [InlineData(66, true)]
        public void IsEven_ShouldReturnCorrectResult(int age, bool expected)
        {
            // Create a new instance of PersonaHelper within the method
            PersonaHelper helper = new PersonaHelper();
            bool result = helper.IsEven(age);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Anna", true, true)]
        [InlineData("Bob", true, true)]
        [InlineData("John", true, false)]
        [InlineData("Alice", false, false)]
        [InlineData("madam", false, true)]
        public void NameAnalyser_ShouldReturnExpectedResult(string name, bool isShort, bool isPalindrome)
        {
            // Create a new instance of PersonaHelper within the method
            PersonaHelper helper = new PersonaHelper();
            (bool IsShort, bool IsPalindrome) result = helper.NameAnalyser(name);
            Assert.Equal(isShort, result.IsShort);
            Assert.Equal(isPalindrome, result.IsPalindrome);
        }

        [Fact]
        public void NameAnalyser_ShouldThrowExceptionForInvalidName()
        {
            PersonaHelper helper = new PersonaHelper();
            Assert.Throws<ArgumentException>(() => helper.NameAnalyser(""));
            Assert.Throws<ArgumentException>(() => helper.NameAnalyser(null));
        }

        [Theory]
        [InlineData("blau", 0)]
        [InlineData("verd", 0)]
        [InlineData("vermell", 1)]
        [InlineData("negre", 1)]
        [InlineData("", -1)]
        [InlineData(null, -1)]
        public void VerifyColour_ShouldReturnExpectedResult(string colour, int expected)
        {
            // Create a new instance of PersonaHelper within the method
            PersonaHelper helper = new PersonaHelper();
            int result = helper.VerifyColour(colour);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("matí", 0)]
        [InlineData("nit", 1)]
        [InlineData("tarda", 2)]
        [InlineData("desconegut", 2)]
        [InlineData("", 2)]
        public void PersonalityTest_ShouldReturnExpectedResult(string preference, int expected)
        {
            // Create a new instance of PersonaHelper within the method
            PersonaHelper helper = new PersonaHelper();
            int result = helper.PersonalityTest(preference);
            Assert.Equal(expected, result);
        }
    }
}

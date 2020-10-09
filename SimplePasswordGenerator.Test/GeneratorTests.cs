using PasswordGenerator.Library;
using System;
using System.Linq;
using Xunit;

namespace SimplePasswordGenerator.Test
{
    public class GeneratorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("a b")]
        public void Specials_WhenWhitespaceOrNullIsProvided_ThrowsGenerationException(string value)
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Specials = value);
        }

        [Fact]
        public void Specials_WhenRandomValidStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();
            string value = GenerateRandomString(100);

            // Act - generate a long random string 
            generator.Specials = value;
            
            // Assert
        }

        [Theory]
        [InlineData("aa", "a")]
        [InlineData("abcabc", "abc")]
        [InlineData("!!!", "!")]
        public void Specials_WhenDuplicateCharsProvided_RemovesDuplicates(string given, string expected)
        {
            // Arrange
            var generator = new Generator();

            // Act
            generator.Specials = given;

            // Assert
            Assert.Equal(expected, generator.Specials);
        }

        private string GenerateRandomString(uint length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numerics = "1234567890";

            var randomString = new string(Enumerable.Repeat(chars + chars.ToLower() + numerics, (int)length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}

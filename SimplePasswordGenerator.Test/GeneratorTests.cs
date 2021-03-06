﻿using System;
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
        public void Specials_WhenWhitespaceOrNullIsProvided_ThrowsGeneratorException(string value)
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Specials = value);
        }

        [Fact]
        public void Specials_WhenEmptyStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            generator.Specials = "";
            generator.Specials = string.Empty;
        }

        [Fact]
        public void Specials_WhenRandomValidStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();
            string value = GenerateRandomString(100);

            // Act
            // Assert
            generator.Specials = value;
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

        [Theory]
        [InlineData(0)]
        [InlineData(1025)]
        public void Generate_WhenLengthIsInvalid_ThrowsGeneratorException(uint length)
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Generate(length));
        }

        [Fact]
        public void Generate_WhenLengthIsValid_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();
            int validLength = GenerateRandomNumber(1, 1024);

            // Act
            // Assert
            generator.Generate((uint)validLength);
        }

        [Fact]
        public void Letters_WhenWhitespaceIsProvided_ThrowsGeneratorException()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Letters = "abc def");
        }

        [Fact]
        public void Letters_WhenNullIsProvided_ThrowGeneratorException()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Letters = null);
        }

        [Fact]
        public void Letters_WhenEmptyStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            generator.Letters = string.Empty;
        }

        [Fact]
        public void Letters_WhenValidStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            generator.Letters = "abc";
        }

        [Fact]
        public void Numerics_WhenWhitespaceIsProvided_ThrowsGeneratorException()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Numerics = "123 456");
        }

        [Fact]
        public void Numerics_WhenNullIsProvided_ThrowsGeneratorException()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            Assert.Throws<GeneratorException>(() => generator.Numerics = null);
        }

        [Fact]
        public void Numerics_WhenEmptyStringIsProvided_DoesNotThrow()
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            generator.Numerics = "";
            generator.Numerics = string.Empty;
        }

        [Theory]
        [InlineData("123")]
        [InlineData("0")]
        [InlineData("12341234")]
        [InlineData("999")]
        public void Numerics_WhenValidStringIsProvided_DoesNotThrow(string value)
        {
            // Arrange
            var generator = new Generator();

            // Act
            // Assert
            generator.Numerics = value;
        }

        private int GenerateRandomNumber(int lowest, int highest)
        {
            var random = new Random();
            var validLength = random.Next(lowest, highest + 1);
            return validLength;
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

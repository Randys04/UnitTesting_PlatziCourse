﻿using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace StringManipulation.Tests
{

    public class StringOperationTest
    {


        [Fact(Skip = "This test isn't valid now, TICKET-001")]
        public void ConcatenateStrings()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Theory]
        [InlineData("oro", true)]
        [InlineData("Hello", false)]
        [InlineData("Messi", false)]
        public void IsPalindrome(string word, bool expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome(word);

            Assert.Equal(expected ,result);
        }


        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();

            var result = strOperations.RemoveWhitespace("Hello I am Randy");

            Assert.Equal("HelloIamRandy", result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var strOperations = new StringOperations();

            var result = strOperations.QuantintyInWords("dog", 2);

            Assert.StartsWith("dos", result);
            Assert.Contains("dog", result);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            var strOperations = new StringOperations();

            var result = strOperations.GetStringLength("Platzi");

            Assert.Equal(6, result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("This is Platzi", 0));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);
            

            var result = strOperations.CountOccurrences("Palabra", 'a');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            //mockFileReader.Setup(p => p.ReadString("informarion.txt")).Returns("This is an information example");
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("This is an information example");

            var result = strOperations.ReadFile(mockFileReader.Object, "information.txt");

            Assert.Equal("This is an information example", result);
        }
    }
}

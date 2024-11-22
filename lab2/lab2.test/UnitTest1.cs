namespace lab2.test
{
using System;
using Xunit;
using Lab2;

namespace Lab2.Test
{
    public class CalculateMinTests
    {
        [Fact]
        public void ConvertTimeToSec_ValidTime_ReturnsCorrectSeconds()
        {
            // Arrange
            string time = "3:15:30";

            // Act
            int result = CalculateMin.ConvertTimeToSec(time);

            // Assert
            Assert.Equal(11730, result); // 3 * 3600 + 15 * 60 + 30
        }

        [Fact]
        public void ConvertSecondsToTime_ValidSeconds_ReturnsCorrectTime()
        {
            // Arrange
            int totalSeconds = 11730;

            // Act
            string result = CalculateMin.ConvertSecondsToTime(totalSeconds);

            // Assert
            Assert.Equal("3:15:30", result);
        }

        [Fact]
        public void ConvertTimeToSec_Midnight_ReturnsZero()
        {
            // Arrange
            string time = "12:00:00";

            // Act
            int result = CalculateMin.ConvertTimeToSec(time);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ConvertSecondsToTime_Midnight_ReturnsCorrectTime()
        {
            // Arrange
            int totalSeconds = 0;

            // Act
            string result = CalculateMin.ConvertSecondsToTime(totalSeconds);

            // Assert
            Assert.Equal("12:00:00", result);
        }

        [Fact]
        public void CalculateMinimumAdjustmentTime_SingleTime_ReturnsSameTime()
        {
            // Arrange
            string[] times = { "3:15:30" };

            // Act
            string result = CalculateMin.CalculateMinimumAdjustmentTime(times);

            // Assert
            Assert.Equal("3:15:30", result);
        }

        [Fact]
        public void CalculateMinimumAdjustmentTime_MultipleTimes_ReturnsCorrectTime()
        {
            // Arrange
            string[] times = { "3:00:00", "9:00:00" };

            // Act
            string result = CalculateMin.CalculateMinimumAdjustmentTime(times);

            // Assert
            Assert.Equal("6:00:00", result); // Мінімальний час між 3:00:00 і 9:00:00
        }

        [Fact]
        public void CalculateMinimumAdjustmentTime_AllTimesAreSame_ReturnsSameTime()
        {
            // Arrange
            string[] times = { "6:30:00", "6:30:00", "6:30:00" };

            // Act
            string result = CalculateMin.CalculateMinimumAdjustmentTime(times);

            // Assert
            Assert.Equal("6:30:00", result);
        }

        [Fact]
        public void CalculateMinimumAdjustmentTime_TimesAroundMidnight_ReturnsCorrectTime()
        {
            // Arrange
            string[] times = { "11:59:59", "12:00:01" };

            // Act
            string result = CalculateMin.CalculateMinimumAdjustmentTime(times);

            // Assert
            Assert.Equal("12:00:00", result); // Баланс між 11:59:59 і 12:00:01
        }

        [Fact]
        public void CalculateMinimumAdjustmentTime_EmptyInput_ThrowsException()
        {
            // Arrange
            string[] times = { };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                CalculateMin.CalculateMinimumAdjustmentTime(times));

            Assert.Contains("Input times cannot be empty", exception.Message);
        }

        [Fact]
        public void ConvertTimeToSec_InvalidFormat_ThrowsException()
        {
            // Arrange
            string invalidTime = "25:00";

            // Act & Assert
            var exception = Assert.Throws<FormatException>(() =>
                CalculateMin.ConvertTimeToSec(invalidTime));

            Assert.Contains("Input string was not in a correct format", exception.Message);
        }
    }
}

}
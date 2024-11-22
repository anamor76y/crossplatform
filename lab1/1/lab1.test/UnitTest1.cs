using System;
using System.Collections.Generic;
using Lab1;
using Xunit;

namespace Lab1.Test
{
    public class FindPositionTests
    {
        [Fact]
        public void CalculatePosition_SimpleCase_ReturnsCorrectPosition()
        {
            // Arrange
            int N = 4;
            int K = 3;
            List<int> arrangement = new List<int> { 1, 2, 3 };

            // Act
            int result = FindPosition.CalculatePosition(N, K, arrangement);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void CalculatePosition_LastPermutation_ReturnsCorrectPosition()
        {
            // Arrange
            int N = 6;
            int K = 4;
            List<int> arrangement = new List<int> { 1, 3, 2, 5 };

            // Act
            int result = FindPosition.CalculatePosition(N, K, arrangement);

            // Assert
            Assert.Equal(14, result); 
        }

        [Fact]
        public void CalculatePosition_PartialPermutation_ReturnsCorrectPosition()
        {
            // Arrange
            int N = 5;
            int K = 3;
            List<int> arrangement = new List<int> { 3, 1, 4 };

            // Act
            int result = FindPosition.CalculatePosition(N, K, arrangement);

            // Assert
            Assert.Equal(26, result);
        }

        [Fact]
        public void CalculatePosition_SingleElement_ReturnsCorrectPosition()
        {
            // Arrange
            int N = 3;
            int K = 2;
            List<int> arrangement = new List<int> { 3, 2 };

            // Act
            int result = FindPosition.CalculatePosition(N, K, arrangement);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void CalculatePosition_EmptyArrangement_ReturnsPositionOne()
        {
            // Arrange
            int N = 4;
            int K = 0;
            List<int> arrangement = new List<int>();

            // Act
            int result = FindPosition.CalculatePosition(N, K, arrangement);

            // Assert
            Assert.Equal(1, result); 
        }
    }
}


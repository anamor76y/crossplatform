using System;
using System.IO;
using Xunit;
using Lab3.Runner;
using LabyrinthLib;

namespace LabyrinthTests
{
    public class LabyrinthSolverTests
    {
        [Fact]
        public void TestFindPrincess_SuccessfulPath()
        {
            // Arrange
            int h = 3, m = 3, n = 3;
            char[][][] labyrinth = new char[h][][];
            labyrinth[0] = new char[][]
            {
                new char[] { '1', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[1] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[2] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '2' }
            };

            // Act
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Assert
            Assert.Equal(30, result); 
        }

        [Fact]
        public void TestFindPrincess_PrincessOnAnotherLevel()
        {
            // Arrange
            int h = 3, m = 3, n = 3;
            char[][][] labyrinth = new char[h][][];
            labyrinth[0] = new char[][]
            {
                new char[] { '1', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[1] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[2] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '2', '.' },
                new char[] { '.', '.', '.' } 
            };

            // Act
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Assert
            Assert.Equal(20, result); 
        }

        [Fact]
        public void TestFindPrincess_PathWithObstacles()
        {
            // Arrange
            int h = 3, m = 3, n = 3;
            char[][][] labyrinth = new char[h][][];
            labyrinth[0] = new char[][]
            {
                new char[] { '1', '.', '.' },
                new char[] { 'o', 'o', '.' },
                new char[] { 'o', 'o', '.' }
            };
            labyrinth[1] = new char[][]
            {
                new char[] { 'o', 'o', '.' },
                new char[] { '.', '.', '.' },
                new char[] { 'o', 'o', 'o' }
            };
            labyrinth[2] = new char[][]
            {
                new char[] { 'o', '.', '.' },
                new char[] { '.', '2', '.' },
                new char[] { '.', '.', '.' } 
            };

            // Act
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Assert
            Assert.Equal(30, result); 
        }

        [Fact]
        public void TestFindPrincess_NoClearPathToPrincess()
        {
            // Arrange
            int h = 3, m = 3, n = 3;
            char[][][] labyrinth = new char[h][][];
            labyrinth[0] = new char[][]
            {
                new char[] { '1', '.', '.' },
                new char[] { '.', '.', 'o' },
                new char[] { '.', 'o', 'o' }
            };
            labyrinth[1] = new char[][]
            {
                new char[] { 'o', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { 'o', '.', '.' }
            };
            labyrinth[2] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { 'o', '2', '.' },
                new char[] { 'o', '.', '.' } 
            };

            // Act
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Assert
            Assert.Equal(20, result); 
        }

        [Fact]
        public void TestFindPrincess_SinglePathToPrincess()
        {
            // Arrange
            int h = 3, m = 3, n = 3;
            char[][][] labyrinth = new char[h][][];
            labyrinth[0] = new char[][]
            {
                new char[] { '1', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[1] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' }
            };
            labyrinth[2] = new char[][]
            {
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '.' },
                new char[] { '.', '.', '2' } 
            };

            // Act
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Assert
            Assert.Equal(30, result); 
        }
    }
}

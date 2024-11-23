using LabyrinthLib;
using System;
using System.IO;

namespace Lab3.Runner
{
    class Program
    {
        static void Main()
        {
            string inputFilePath = Path.Combine("../input.txt");
            string[] inputLines = File.ReadAllLines(inputFilePath);

            string[] dimensions = inputLines[0].Split(' ');
            int h = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);
            int n = int.Parse(dimensions[2]);

            char[][][] labyrinth = new char[h][][];

            int lineIndex = 1; 
            List<char[][]> levels = new List<char[][]>();

            char[][] currentLevel = new char[m][];
            for (int z = 0; z < h; z++)
            {
                currentLevel = new char[m][];
                for (int x = 0; x < m; x++)
                {
                    while (string.IsNullOrWhiteSpace(inputLines[lineIndex]))
                    {
                        lineIndex++;
                    }

                    currentLevel[x] = inputLines[lineIndex++].ToCharArray();
                }
                levels.Add(currentLevel);
            }

            labyrinth = levels.ToArray();
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            string outputFilePath = Path.Combine("../output.txt");
            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}

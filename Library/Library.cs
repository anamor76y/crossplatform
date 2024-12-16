using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using LabUtils;

namespace Library
{
    public static class Prog
    {
        public static string Lab1(string inputPath, string outputPath)
        {
            try
            {
                var input = File.ReadAllLines(inputPath)
                                    .Where(line => !string.IsNullOrWhiteSpace(line))
                                    .ToArray();
                var nk = input[0].Split().Select(int.Parse).ToArray();
                int N = nk[0];
                int K = nk[1];
                var arrangement = input[1].Split().Select(int.Parse).ToList();

                int result = FindPosition.CalculatePosition(N, K, arrangement);
                File.WriteAllText(outputPath, result.ToString());

                return result.ToString(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return null; 
            }
        }

        public static string Lab2(string inputPath, string outputPath)
        {
            try
            {
                string[] inputLines = File.ReadAllLines(inputPath);

                int N = int.Parse(inputLines[0]);
                string[] times = inputLines.Skip(1).Take(N).ToArray();

                string result = CalculateMin.CalculateMinimumAdjustmentTime(times);

                File.WriteAllText(outputPath, result);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return null;
            }
        }

        public static string Lab3(string inputPath, string outputPath)
        {
            try
            {
                string[] inputLines = File.ReadAllLines(inputPath);

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

                File.WriteAllText(outputPath, result.ToString());
                return result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return null;
            }
        }
    }
}

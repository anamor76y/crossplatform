using LabyrinthLib;
using System;
using System.IO;

namespace Lab3.Runner
{
    class Program
    {
        static void Main()
        {
            // Читаємо вхідні дані з файлу
            string inputFilePath = Path.Combine("../input.txt");
            string[] inputLines = File.ReadAllLines(inputFilePath);

            // Розбираємо перший рядок для отримання розмірів лабіринту
            string[] dimensions = inputLines[0].Split(' ');
            int h = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);
            int n = int.Parse(dimensions[2]);

            // Ініціалізуємо тривимірний масив для лабіринту
            char[][][] labyrinth = new char[h][][];

            int lineIndex = 1; // Початковий індекс для рядків лабіринту
            List<char[][]> levels = new List<char[][]>();

            // Читаємо лабіринт
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

            // Переводимо список в масив
            labyrinth = levels.ToArray();

            // Передаємо дані до функції обчислення
            int result = LabyrinthSolver.FindPrincess(h, m, n, labyrinth);

            // Записуємо результат в файл OUTPUT.TXT
            string outputFilePath = Path.Combine("../output.txt");
            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}

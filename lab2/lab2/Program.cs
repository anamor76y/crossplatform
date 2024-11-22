namespace Lab2
{
    public static class Program
    {
        public static void Main()
        {
            string inputPath = Path.Combine("input.txt");
            string[] inputLines = File.ReadAllLines(inputPath);

            int N = int.Parse(inputLines[0]);
            string[] times = inputLines.Skip(1).Take(N).ToArray();

            string result = CalculateMin.CalculateMinimumAdjustmentTime(times);
            string outputPath = Path.Combine("output.txt");

            File.WriteAllText(outputPath, result);
        }
    }
}

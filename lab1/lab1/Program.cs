namespace Lab1
{

    public class Program
    {
        static void Main()
        {
            string inputPath = Path.Combine("input.txt");
            var input = File.ReadAllLines(inputPath)
                                .Where(line => !string.IsNullOrWhiteSpace(line))
                                .ToArray();
            var nk = input[0].Split().Select(int.Parse).ToArray();
            int N = nk[0];
            int K = nk[1];
            var arrangement = input[1].Split().Select(int.Parse).ToList();

            int result = FindPosition.CalculatePosition(N, K, arrangement);
            string outputPath = Path.Combine("output.txt");
            File.WriteAllText(outputPath, result.ToString());
        }
    }
}

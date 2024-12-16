using System;
using System.Linq;
using System.Collections.Generic;

namespace LabUtils;

    public class FindPosition
    {
        private static int Factorial(int x)
        {
            if (x <= 1) return 1;
            return x * Factorial(x - 1);
        }

        public static int CalculatePosition(int N, int K, List<int> arrangement)
        {
            List<int> availableNumbers = Enumerable.Range(1, N).ToList();
            int position = 0;

            for (int i = 0; i < K; i++)
            {

                int number = arrangement[i];
                int index = availableNumbers.IndexOf(number);

                position += index * Factorial(N - i - 1) / Factorial(N - K);

                availableNumbers.RemoveAt(index);
            }

            return position + 1;
        }
    }
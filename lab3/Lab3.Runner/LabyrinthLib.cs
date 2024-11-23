using System;
using System.Collections.Generic;

namespace LabyrinthLib
{
    public class LabyrinthSolver
    {
        public static int FindPrincess(int h, int m, int n, char[][][] labyrinth)
        {
            Tuple<int, int, int> start = null, goal = null;
            for (int z = 0; z < h; z++)
            {
                for (int x = 0; x < m; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        if (labyrinth[z][x][y] == '1')
                        {
                            start = Tuple.Create(z, x, y);
                        }
                        else if (labyrinth[z][x][y] == '2')
                        {
                            goal = Tuple.Create(z, x, y);
                        }
                    }
                }
            }

            var moves = new (int dz, int dx, int dy)[]
            {
                (0, -1, 0), (0, 1, 0), (0, 0, -1), (0, 0, 1), (-1, 0, 0), (1, 0, 0)
            };

            var queue = new Queue<Tuple<int, int, int, int>>();
            var visited = new bool[h, m, n];
            visited[start.Item1, start.Item2, start.Item3] = true;
            queue.Enqueue(Tuple.Create(start.Item1, start.Item2, start.Item3, 0));

            while (queue.Count > 0)
            {
                var (z, x, y, time) = queue.Dequeue();
                if (z == goal.Item1 && x == goal.Item2 && y == goal.Item3)
                {
                    return time;
                }

                foreach (var (dz, dx, dy) in moves)
                {
                    int nz = z + dz, nx = x + dx, ny = y + dy;
                    if (nz >= 0 && nz < h && nx >= 0 && nx < m && ny >= 0 && ny < n)
                    {
                        if (!visited[nz, nx, ny] && (labyrinth[nz][nx][ny] == '.' || labyrinth[nz][nx][ny] == '2'))
                        {
                            visited[nz, nx, ny] = true;
                            queue.Enqueue(Tuple.Create(nz, nx, ny, time + 5));
                        }
                    }
                }
            }

            return -1; 
        }
    }
}

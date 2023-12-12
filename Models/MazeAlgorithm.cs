namespace GettingStarted.Models
{
    public class MazeAlgorithm
    {
        Random random = new Random();

        public int[,] GenerateMaze(int rows, int cols)
        {
            int[,] maze = new int[rows, cols];

            // Initialize maze with walls
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = 1;
                }
            }

            // Set starting point
            maze[1, 1] = 0;

            DFS(maze, 1, 1);

            return maze;
        }

        void DFS(int[,] maze, int row, int col)
        {
            int[] directions = { 1, 2, 3, 4 };
            Shuffle(directions);

            foreach (int dir in directions)
            {
                int[] dRow = { 0, 0, 1, -1 };
                int[] dCol = { 1, -1, 0, 0 };

                int newRow = row + 2 * dRow[dir - 1];
                int newCol = col + 2 * dCol[dir - 1];

                if (newRow > 0 && newRow < maze.GetLength(0) - 1 &&
                    newCol > 0 && newCol < maze.GetLength(1) - 1 &&
                    maze[newRow, newCol] == 1)
                {
                    maze[row + dRow[dir - 1], col + dCol[dir - 1]] = 0;
                    maze[newRow, newCol] = 0;

                    DFS(maze, newRow, newCol);
                }
            }
        }

        void Shuffle(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                int temp = array[r];
                array[r] = array[i];
                array[i] = temp;
            }
        }
    } 
}

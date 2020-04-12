using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Result
    {

        /*
         * Complete the 'minMoves' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. 2D_INTEGER_ARRAY maze
         *  2. INTEGER x
         *  3. INTEGER y
         */

        

         public static int minMoves(List<List<int>> maze, int x, int y)
        {
            int count = -1;
            int gold = 0;
            int tempRow = 0;
            int tempCol = 0;
            int leftCount = 0;
            int RightCount = 0;
            int totalPath = (x + 1) * maze[0].Count;
            if (maze[0][1] == 1 && maze[1][0] == 1)
            {
                return -1;
            }

            for (int row = 0; row < maze.Count; row++)
            {
                for (int col = 0; col < maze[0].Count; col++)
                {
                    count = count + 1;
                    
                    if (totalPath <= 0)
                    {
                        if ((tempCol == y && tempRow + 1 == x) || (tempRow == x && tempCol + 1 == y))
                        {
                            gold++;
                            return gold;
                        }
                        return count;
                    }
                    if(row==x)
                    {
                        for (int i = 0; i < x; i++)
                        {
                            leftCount++;
                            if (maze[row][i] == 2)
                            {
                                count = count + leftCount;
                                tempRow = row;
                                tempCol = i;
                                gold = count;
                            }
                            totalPath--;
                        }
                        for (int i = maze[row].Count-1; i > x; i--)
                        {
                            RightCount++;
                            if (maze[row][i] == 2)
                            {
                                count = count + RightCount;
                                tempRow = row;
                                tempCol = i;
                                gold = count;
                            }
                            totalPath--;
                        }
                    }
                    if (maze[row][col] == 2)
                    {
                        tempRow = row;
                        tempCol = col;
                        gold = count;
                    }
                    if (maze[row][col] == 1)
                    {
                        count = count - 1;
                    }
                    totalPath--;
                }
            }

            return count;
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int mazeRows = Convert.ToInt32(Console.ReadLine().Trim());
            int mazeColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> maze = new List<List<int>>();

            for (int i = 0; i < mazeRows; i++)
            {
                maze.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(mazeTemp => Convert.ToInt32(mazeTemp)).ToList());
            }

            int x = Convert.ToInt32(Console.ReadLine().Trim());

            int y = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.minMoves(maze, x, y);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}

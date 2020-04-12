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
                int loop = 0;
                for (int col = 0; col < maze[0].Count; col++)
                {
                    count += 1;
                    if (totalPath <= 0)
                    {
                        if ((tempCol == y && tempRow + 1 == x) || (tempRow == x && tempCol + 1 == y))
                        {
                            gold++;
                            return gold;
                        }
                        return count;
                    }
                    if (row == x)
                    {
                        int found = 0;
                        for (int i = 0; i < x - 1; i++)
                        {
                            if (i == y) 
                            {
                                if (found > 0)
                                {
                                    return count + RightCount;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (maze[row][i] == 1)
                            {
                                count = count - 1;
                                break;
                            }
                            else if (maze[row][i] == 2)
                            {
                                found++;
                                count = count + leftCount;
                                tempRow = row;
                                tempCol = i;
                                gold = count;
                            }
                            leftCount++;
                            totalPath--;
                        }
                        for (int i = maze[row].Count; i >= x; i--)
                        {
                            if ((i - 1) == y)
                            {
                                RightCount++;
                                return count + RightCount;
                            }
                            else if (maze[row][i - 1] == 1)
                            {
                                break;
                            }
                            else if (maze[row][i - 1] == 2)
                            {
                                tempRow = row;
                                tempCol = i;
                                gold = count + RightCount;
                            }
                            RightCount++;
                            totalPath--;
                        }
                    }
                    if (maze[row][col] == 2)
                    {
                        tempRow = row;
                        tempCol = col;
                        gold = count;
                        loop++;
                    }
                    if (maze[row][col] == 1)
                    {
                        count = count - 1;
                    }
                    if(loop==0 && col==maze[0].Count-1)
                    {
                        count = count - maze[0].Count - 1;
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

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
            int count = 0;
            
            if (maze[0][1]==1 && maze[1][0]==1)
            {
                return -1;
            }
            
            for (int row = 0; row < maze.Count; row++)
            {
                for (int col = 0; col < maze[0].Count; col++)
                {
                    if (col == y)
                    {
                        if (row + 1 == x)
                        {
                            count++;
                            return count;
                        }
                        else if (maze[row + 1][col] != 1)
                        {
                            count++;
                                break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count++;
                    }
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

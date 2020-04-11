using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



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
        int inerCount = 0;
        int outCount=0;
        int r = 0;
        int c = 0;
        bool check=false;
        Console.WriteLine(maze[1][1]);
        if(maze[x][y]==1){
            return -1;
        }
        else
        {
            for(int row=r; row<maze.Count;row++)
            {
                for(int col=c;col<maze[0].Count;col++)
                {
                    inerCount = inerCount+1;
                    if(row==x && col==y && check==false)
                    {
                        Console.WriteLine(maze[row][col]);
                            if(maze[x][y]==1)
                            {
                                return -1;
                            }
                            else if(maze[row][col]==2)
                            {
                                return inerCount;
                            }
                            else
                            {
                                r=0;
                                c=0;
                                check = true;
                            }
                    }
                    
                    else if(check==true && (maze[row][col]==2))
                    {
                        return outCount;
                    }
                    outCount = outCount+1;
                }
            }
            return outCount;
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

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

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

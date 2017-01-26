using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stairsfinal
{
    public class Staircase
    {
        static void Main(string[] args)
        {

            int rows = 6;
            int columns = 6;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int spaces = columns - (row + 1);
                    if (col >= spaces)
                    {
                        Console.Write("X");
                    }

                    else
                    {
                        Console.Write(" ");

                    }

                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

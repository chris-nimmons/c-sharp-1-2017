using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staircase
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 6;
            int cols = 6;
            for (int row = 0; row < rows; row++)
            {
                int spaces = cols - (row + 1);

               for (int col = 0; col < cols; col++)
                {
                  if (col >= spaces)
                    {
                        Console.Write("x");
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


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
            for (int x = 1; x <= 6; x++)
            {
                for (int y = 1; y <= (6 - x); y++)
                {
                    Console.Write(" ");
                }
                for (int z = 1; z <= x; z++)
                {
                    Console.Write("x");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}
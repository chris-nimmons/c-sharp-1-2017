using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string stairCase = "";
            char addX = 'x';
            string space = " ";
            int numSteps = 6;

            for (int x = 0; x < numSteps; x++)
            {
                for (int y = x; y < numSteps - 1; y++)
                {
                    
                    Console.Write(space);
                }

                stairCase = stairCase + addX;            
                Console.WriteLine(stairCase);
            }
            
            Console.ReadLine();
        }
    }
}

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


            //Different way to do it

            //int rows = 6;
            //int columns = 6;

            //for (int row = 0; row < rows; row++)
            //{
            //    int spaces = columns - row - 1;

            //    for (int col = 0; col < columns; col++)
            //    {

            //        if (col >= spaces)
            //        {
            //            Console.Write("X");
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();



            //}
            //Console.ReadLine();


        }
    }
}

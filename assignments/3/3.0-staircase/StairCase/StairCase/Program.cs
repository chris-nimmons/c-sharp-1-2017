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
            PrintStairs(53);
            Console.ReadLine();
        }

        static void PrintStairs(int totalSteps)
        {
            StairBuilder stairBuilder = new StairCase.StairBuilder();
            for (int i = 1; i <= totalSteps; i++)
            {
                Console.WriteLine(stairBuilder.NextStep(i, totalSteps));
            }
        }
    }
}

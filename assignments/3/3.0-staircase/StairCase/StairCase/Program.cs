﻿using System;
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

        static void PrintWithStairBuilder(int totalSteps)
        {
            StairBuilder stairBuilder = new StairCase.StairBuilder();
            for (int i = 1; i <= totalSteps; i++)
            {
                Console.WriteLine(stairBuilder.NextStep(i, totalSteps));
            }
        }

        static void PrintStairs(int totalSteps)
        {
            for (int steps = 1; steps <= totalSteps; steps++)
            {
                for (int blanks = steps; blanks <= totalSteps - 1; blanks++)
                {
                    Console.Write(" ");
                }

                for (int exes = steps; exes > 0; exes--)
                {
                    Console.Write("x");
                }
                Console.WriteLine();
            }
        }

        static void PrintWithStairArrays(int totalSteps)
        {
            char[] currentStep = new char[totalSteps];

            for (int i = 0; i < totalSteps; i++)
            {
                currentStep[i] = ' ';
            }

            for (int i = totalSteps - 1; i >= 0; i--)
            {
                currentStep[i] = 'x';
                foreach (char character in currentStep)
                {
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        }
    }
}

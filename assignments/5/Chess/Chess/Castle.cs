﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Castle :  Pieces
    {
        public int X = 10;
        public int Y = 10;
        public int spaces = 10;

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Castle");

            for (int c = 0; c < X + spaces; c++)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("X");
                
                    Console.SetCursorPosition(c , Y);
                Console.Write("X");

                for (int r = 0; r < Y + spaces; r++)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");

                    Console.SetCursorPosition(X, r);
                    Console.Write("X");

                }
            }

            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }
    }
}

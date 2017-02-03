using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen : Pieces
    {


        public void Render()
        {
            int X = 10;
            int Y = 10;
            int spaces = 10;

            Console.SetCursorPosition(0, 0);
            Console.Write("Queen");

            for (int a = 0; a < spaces; a++)
            {
                Console.SetCursorPosition(X + a, Y + a);
                Console.Write("X");

                Console.SetCursorPosition(X - a, Y - a);
                Console.Write("X");

                Console.SetCursorPosition(X + a, Y - a);
                Console.Write("X");

                Console.SetCursorPosition(X - a, Y + a);
                Console.Write("X");


                for (int c = 0; c < X + spaces; c++)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");

                    Console.SetCursorPosition(c, Y);
                    Console.Write("X");

                    for (int r = 0; r < Y + spaces; r++)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.Write("X");

                        Console.SetCursorPosition(X, r);
                        Console.Write("X");
                    }
                    Console.SetCursorPosition(10, 10);
                    Console.Write(0);
                }
            }

        }
    }
}



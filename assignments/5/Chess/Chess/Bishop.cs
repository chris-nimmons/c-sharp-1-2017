using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Pieces
    {



        public void Render()
        {
            int X = 10;
            int Y = 10;
            int spaces = 10;

            Console.SetCursorPosition(0, 0);
            Console.Write("Bishop");

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

                //Console.SetCursorPosition(X + spaces + 1, Y + spaces + 1);
                //Console.Write("X");

                //Console.SetCursorPosition(X - spaces - 1, Y - spaces - 1);
                //Console.Write("X");

                //Console.SetCursorPosition(X + spaces + 1, Y - spaces - 1);
                //Console.Write("X");

                //Console.SetCursorPosition(X - spaces - 1, Y + spaces + 1);
                //Console.Write("X");

            }
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }

    }
}

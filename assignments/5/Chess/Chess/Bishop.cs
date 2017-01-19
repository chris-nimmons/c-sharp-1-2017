using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Pieces
    {
        public int X = 10;
        public int Y = 10;
        public int spaces = 10;
        

        public void Render()
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Castle : Piece
    {


        public void Render()
        {
            int X = 10;
            int Y = 10;
            int moves = 10;

            for (int i = 0; i < moves; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("X");
                Console.SetCursorPosition(X, Y - i);
                Console.Write("X");
            }
            for (int i = 0; i < moves; i++)
            {
                Console.SetCursorPosition(X+i, Y);
                Console.Write("X");
                Console.SetCursorPosition(X-i, Y);
                Console.Write("X");
            }
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
            Console.SetCursorPosition(0, 1);
            Console.Write("---Castle---");

        }
    }
}

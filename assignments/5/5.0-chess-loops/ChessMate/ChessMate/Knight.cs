using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
   public class Knight : Piece
    {

        public void Render()
        {
            x = 10;
            y = 10;

            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("X");

            Console.SetCursorPosition(x + 2, y - 1);
            Console.Write("X");

            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("X");

            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("X");

            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write("X");

            Console.SetCursorPosition(x + 1, y - 2);
            Console.Write("X");

            Console.SetCursorPosition(x - 1, y - 2);
            Console.Write("X");

            Console.SetCursorPosition(x - 1, y + 2);
            Console.Write("X");


            Console.SetCursorPosition(x, y);
            Console.Write("O");

            Console.SetCursorPosition(7, 0);
            Console.Write("Knight");

        }
    }
}

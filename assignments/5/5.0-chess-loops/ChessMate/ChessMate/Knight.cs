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
            X = 10;
            Y = 10;

            Console.SetCursorPosition(X + 2, Y + 1);
            Console.Write("X");

            Console.SetCursorPosition(X + 2, Y - 1);
            Console.Write("X");

            Console.SetCursorPosition(X - 2, Y + 1);
            Console.Write("X");

            Console.SetCursorPosition(X - 2, Y - 1);
            Console.Write("X");

            Console.SetCursorPosition(X + 1, Y + 2);
            Console.Write("X");

            Console.SetCursorPosition(X + 1, Y - 2);
            Console.Write("X");

            Console.SetCursorPosition(X - 1, Y - 2);
            Console.Write("X");

            Console.SetCursorPosition(X - 1, Y + 2);
            Console.Write("X");


            Console.SetCursorPosition(X, Y);
            Console.Write("O");

            Console.SetCursorPosition(7, 0);
            Console.Write("Knight");

        }
    }
}

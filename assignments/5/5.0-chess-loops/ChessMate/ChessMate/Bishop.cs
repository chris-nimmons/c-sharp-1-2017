using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
   public class Bishop : Piece
    {

        public void Render()
        {
            X = 10;
            Y = 10;
            moves = 10;

            for (int i = 0; i <= moves; i++)
            {

                Console.SetCursorPosition(X, Y);
                Console.Write("X");

                Console.SetCursorPosition(X - i, Y + i);
                Console.Write("X");

                Console.SetCursorPosition(X + i, Y - i);
                Console.Write("X");

                Console.SetCursorPosition(X + i, Y + i);
                Console.Write("X");

                Console.SetCursorPosition(X - i, Y - i);
                Console.Write("X");

            }
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
            Console.SetCursorPosition(7, 0);
            Console.Write("Bishop");
        }
    }
}

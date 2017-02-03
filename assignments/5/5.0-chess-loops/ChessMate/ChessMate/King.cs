using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
   public class King : Piece
    {
        public void Render()
        {
            X = 10;
            Y = 10;
            moves = 1;

            for (int col = X; col <= X + moves; col++)
            {

                Console.SetCursorPosition(col, Y);
                Console.Write("X");

                Console.SetCursorPosition(col, Y + moves);
                Console.Write("X");

                Console.SetCursorPosition(col, Y - moves);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, Y);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, Y - moves);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, Y + moves);
                Console.Write("X");

                Console.SetCursorPosition(10, 10);
                Console.Write("O");

                Console.SetCursorPosition(8, 0);
                Console.Write("King");

            }

        }
    }
}

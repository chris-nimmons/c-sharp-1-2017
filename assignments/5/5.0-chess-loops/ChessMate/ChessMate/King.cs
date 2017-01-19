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
            x = 10;
            y = 10;
            moves = 1;

            for (int col = x; col <= x + moves; col++)
            {

                Console.SetCursorPosition(col, y);
                Console.Write("X");

                Console.SetCursorPosition(col, y + moves);
                Console.Write("X");

                Console.SetCursorPosition(col, y - moves);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, y);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, y - moves);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, y + moves);
                Console.Write("X");

                Console.SetCursorPosition(10, 10);
                Console.Write("O");

                Console.SetCursorPosition(8, 0);
                Console.Write("King");

            }

        }
    }
}

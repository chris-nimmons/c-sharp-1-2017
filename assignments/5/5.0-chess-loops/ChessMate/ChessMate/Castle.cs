using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
    public class Castle : Piece
    {

        public void Render()
        {
            x = 10;
            y = 10;
            moves = 10;

            for (int col = x; col <= x + moves; col++)
            {

                Console.SetCursorPosition(col, y);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, y);
                Console.Write("X");
                for (int row = y; row <= y + moves; row++)
                {
                    Console.SetCursorPosition(x, row);
                    Console.Write("X");

                    Console.SetCursorPosition(x, row - moves);
                    Console.Write("X");

                    Console.SetCursorPosition(10, 10);
                    Console.Write("O");

                    Console.SetCursorPosition(7, 0);
                    Console.Write("Castle");
                }
            }
        }
    }
}

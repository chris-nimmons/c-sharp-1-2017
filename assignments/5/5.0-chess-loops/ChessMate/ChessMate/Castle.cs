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
            X = 10;
            Y = 10;
            moves = 10;

            for (int col = X; col <= X + moves; col++)
            {

                Console.SetCursorPosition(col, Y);
                Console.Write("X");

                Console.SetCursorPosition(col - moves, Y);
                Console.Write("X");
                for (int row = Y; row <= Y + moves; row++)
                {
                    Console.SetCursorPosition(X, row);
                    Console.Write("X");

                    Console.SetCursorPosition(X, row - moves);
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

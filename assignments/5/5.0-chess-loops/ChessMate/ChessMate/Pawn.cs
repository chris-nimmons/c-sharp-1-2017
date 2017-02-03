using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
    public class Pawn : Piece
    {

        public void Render()
        {
            X = 10;
            Y = 10;

            Console.SetCursorPosition(X, Y);
            Console.Write("O");

            Console.SetCursorPosition(X, Y - 1);
            Console.Write("X");

            Console.SetCursorPosition(8, 0);
            Console.Write("Pawn");
        }
    }
}

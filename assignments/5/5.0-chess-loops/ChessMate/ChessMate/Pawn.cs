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
            x = 10;
            y = 10;

            Console.SetCursorPosition(x, y);
            Console.Write("O");

            Console.SetCursorPosition(x, y - 1);
            Console.Write("X");

            Console.SetCursorPosition(8, 0);
            Console.Write("Pawn");
        }
    }
}

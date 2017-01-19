using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Bishop : Piece
    {
        public void BishopPiece()
        {
            int height = 3;
            int width = 3;


            for (int x = 0; x < width + xOffset; x++)
            {
                for (int y = yOffset; y < height + yOffset; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('X');
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}

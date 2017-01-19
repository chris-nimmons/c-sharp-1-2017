using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessBoard.Program;

namespace ChessBoard
{
    class Castle : Piece
    {
        public void CastlePiece()
        {
            int height = 3;
            int width = 3;
            int xOffset = 10;
            int yOffset = 10;

            for (int x = xOffset; x < width + xOffset; x++)
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

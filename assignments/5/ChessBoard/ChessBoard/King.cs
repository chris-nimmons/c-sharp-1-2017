using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessBoard
{
    class King : Piece
    {
        public void KingPiece()
        {
            int Width = 3;
            int Height = 6;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
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



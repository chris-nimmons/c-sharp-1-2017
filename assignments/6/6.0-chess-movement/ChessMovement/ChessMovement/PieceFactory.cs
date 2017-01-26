using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class PieceFactory
    {
        public Piece CreatePiece(PieceID index, int x, int y, bool taken = false)
        {
            return new Piece() { X = x, Y = y, ID = index, Taken = taken };
        }
    }
}

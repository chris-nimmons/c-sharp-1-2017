using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class PieceFactory
    {
        public Piece CreatePiece(PieceIndex index, int x, int y)
        {
            switch ((Type)(index.ToString()[0]))
            {
                case Type.Pawn:
                    return new Pawn() { X = x, Y = y, ID = index };
                case Type.Rook:
                    return new Rook() { X = x, Y = y, ID = index };
                case Type.Bishop:
                    return new Bishop() { X = x, Y = y, ID = index };
                case Type.Queen:
                    return new Queen() { X = x, Y = y, ID = index };
                case Type.Night:
                    return new Knight() { X = x, Y = y, ID = index };
                case Type.King:
                    return new King() { X = x, Y = y, ID = index };
            }
            return null;
        }
    }
}

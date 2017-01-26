using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PieceID ID { get; set; }
        public PieceType Type { get { return (PieceType)(ID.ToString()[0]); } }
        public char Glyph { get { return Type.ToString()[0]; } }
        public Color Color { get { return (Color)(ID.ToString()[2]); } }
        public bool Taken { get; set; }

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

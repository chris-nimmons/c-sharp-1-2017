using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public enum Type
    {
        Pawn = 'P',
        Rook = 'R',
        Night = 'N',
        Bishop = 'B',
        Queen = 'Q',
        King = 'K'
    }

    public enum Color
    {
        Black = 'B',
        White = 'W'
    }

    public enum PieceIndex
    {
        R1B, N1B, B1B, Q1B, K1B, B2B, N2B, R2B,
        P1B, P2B, P3B, P4B, P5B, P6B, P7B, P8B,
        P1W, P2W, P3W, P4W, P5W, P6W, P7W, P8W,
        R1W, N1W, B1W, Q1W, K1W, B2W, N2W, R2W
    }

    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Takeable { get; set; }
    }

    public abstract class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PieceIndex ID { get; set; }
        public Type Type { get { return (Type)(ID.ToString()[0]); } }
        public char Glyph { get { return Type.ToString()[0]; } }
        public Color Color { get { return (Color)(ID.ToString()[2]); } }
        public Cell[,] Board { get; set; }
        public bool Taken { get; set; }

        public abstract List<Move> GetMoves();
    }
}

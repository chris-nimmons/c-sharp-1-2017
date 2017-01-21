using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    public enum Limit
    {
        Size = 7, // Refers to the size of the board - 1 indicating the maximum array position
        Left = 0,
        Upper = 0,
        Right = Left + Size,
        Lower = Upper + Size
    }

    public enum Color
    {
        White = ConsoleColor.White,
        Black = ConsoleColor.Black
    }

    public enum Type
    {
        Pawn = 'P',
        Rook = 'R',
        Queen = 'Q',
        King = 'K',
        Bishop = 'B',
        Knight = 'H'
    }

    public enum PieceID
    {
        P1, P2, P3, P4, P5, P6, P7, P8,
        R1, H1, B1, Q,  K,  B2, H2, R2
    }

    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Takeable { get; set; }
    }

    public interface IPiece
    {
        int X { get; set; }
        int Y { get; set; }
        Type Type { get; set; }
        Color Color { get; set; }
        int TimesMoved { get; set; }

        List<Move> GetMoves();
    }

    public class Piece
    {
        public PieceID ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Type Type { get; set; }
        public Color Color { get; set; }
        public int TimesMoved { get; set; }
        public Cell[][,] Boards { get; set; }
        public List<Move> PossibleMoves { get; set; }
        public Cell[,] PresentBoard { get; set; }

        public Piece()
        {
            TimesMoved = 0;
            PossibleMoves = new List<Move>();
        }

        protected List<Move> LeftRight()
        {
            var possibleMovements = new List<Move>();

            for (int i = 0 - X; i <= (int)Limit.Size; i++)
            {
                possibleMovements.Add(new Move() { X = X + i, Y = Y });
            }

            return possibleMovements;
        }

        protected List<Move> UpDown()
        {
            var possibleMovements = new List<Move>();

            for (int i = 0 - Y; i <= (int)Limit.Size; i++)
            {
                possibleMovements.Add(new Move() { X = X, Y = Y + i });
            }

            return possibleMovements;
        }

        protected List<Move> DiagonalDown()
        {
            var possibleMovements = new List<Move>();

            for (int i = 0 - X; i <= (int)Limit.Size; i++)
            {
                possibleMovements.Add(new Move() { X = X + i, Y = Y + i });
            }

            return possibleMovements;
        }

        protected List<Move> DiagonalUp()
        {
            var possibleMovements = new List<Move>();

            for (int i = 0; i <= (int)Limit.Size; i++)
            {
                possibleMovements.Add(new Move() { X = X + i, Y = Y - i });
                possibleMovements.Add(new Move() { X = X - i, Y = Y + i });
            }

            return possibleMovements;
        }

        protected bool OffBoard(Move move)
        {
            if (move.X < (int)Limit.Left || move.Y < (int)Limit.Upper || move.X > (int)Limit.Right || move.Y > (int)Limit.Lower)
            {
                return true;
            }
            return false;
        }
    }

    public class Queen : Piece
    {
        public Queen()
        {
            Type = Type.Queen;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            possibleMovements.AddRange(LeftRight());
            possibleMovements.AddRange(UpDown());
            possibleMovements.AddRange(DiagonalDown());
            possibleMovements.AddRange(DiagonalUp());

            possibleMovements.RemoveAll(OffBoard);

            return possibleMovements;
        }
    }

    public class King : Piece
    {
        public King()
        {
            Type = Type.King;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            possibleMovements.Add(new Move() { X = X + 1, Y = Y });         // One right
            possibleMovements.Add(new Move() { X = X + 1, Y = Y + 1 });     // One right and down
            possibleMovements.Add(new Move() { X = X + 1, Y = Y - 1 });     // One right and up
            possibleMovements.Add(new Move() { X = X, Y = Y + 1 });         // One up
            possibleMovements.Add(new Move() { X = X, Y = Y - 1 });         // One down
            possibleMovements.Add(new Move() { X = X - 1, Y = Y });         // One left
            possibleMovements.Add(new Move() { X = X - 1, Y = Y + 1 });     // One left and down
            possibleMovements.Add(new Move() { X = X - 1, Y = Y - 1 });     // One left and up

            possibleMovements.RemoveAll(OffBoard);
            return possibleMovements;
        }
    }

    public class Pawn : Piece
    {
        public Pawn()
        {
            Type = Type.Pawn;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            possibleMovements.Add(new Move() { X = X, Y = Y + 1 * (int)Color });

            if (TimesMoved == 0)
            {
                possibleMovements.Add(new Move() { X = X, Y = Y + 2 * (int)Color });
            }

            possibleMovements.RemoveAll(OffBoard);
            return possibleMovements;
        }
    }

    public class Bishop : Piece
    {
        public Bishop()
        {
            Type = Type.Bishop;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            possibleMovements.AddRange(DiagonalDown());
            possibleMovements.AddRange(DiagonalUp());

            possibleMovements.RemoveAll(OffBoard);

            return possibleMovements;
        }
    }

    public class Rook : Piece
    {
        public Rook()
        {
            Type = Type.Rook;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            possibleMovements.AddRange(UpDown());
            possibleMovements.AddRange(LeftRight());

            possibleMovements.RemoveAll(OffBoard);

            return possibleMovements;
        }
    }

    public class Knight : Piece
    {
        public Knight()
        {
            Type = Type.Knight;
        }

        public List<Move> GetMoves()
        {
            var possibleMovements = new List<Move>();

            for (int i = 1; i <= 2; i++)
            {
                possibleMovements.Add(new Move() { X = X + i - 3, Y = Y + i });
                possibleMovements.Add(new Move() { X = X + i - 3, Y = Y + i * -1 });
                possibleMovements.Add(new Move() { X = X + i, Y = Y + i - 3 });
                possibleMovements.Add(new Move() { X = X + i, Y = Y + (i - 3) * -1 });
            }

            possibleMovements.RemoveAll(OffBoard);

            return possibleMovements;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    public enum Limit
    {
        Size = 8,
        Left = 5,
        Upper = 5,
        Right = Left + Size - 1,
        Lower = Upper + Size - 1
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

    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public interface IPiece
    {
        int X { get; set; }
        int Xi { get; }
        int Y { get; set; }
        int Yi { get; }
        Type Type { get; set; }
        Color Color { get; set; }
        int TimesMoved { get; set; }

        List<Move> GetMoves();
    }

    public class Piece
    {
        public int X { get; set; }
        public int Xi { get { return (int)Limit.Left - X; } }
        public int Y { get; set; }
        public int Yi { get { return (int)Limit.Upper - Y; } }
        public Type Type { get; set; }
        public Color Color { get; set; }
        public int TimesMoved { get; set; }

        public Piece()
        {
            TimesMoved = 0;
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

    public class Queen : Piece, IPiece
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

    public class King : Piece, IPiece
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

    public class Pawn : Piece, IPiece
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

    public class Bishop : Piece, IPiece
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

    public class Rook : Piece, IPiece
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

    public class Knight : Piece, IPiece
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

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

    public class Pawn : Piece
    {
        public Pawn()
        {
            Board = new Cell[8, 8];
        }

        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();
            
            if (Color == Color.White) // White pawns can only move up the board
            {
                if (Y == 0) // Check if the white pawn reached the other side of the board
                {
                    Board[X, Y].Piece = new Rook() { X = X, Y = Y }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                    return proposedMoves;
                }

                if (Y == 6) // Pawns can move two spaces on their first move
                {
                    if (Board[X, Y - 2] == null || Board[X, Y - 2].Piece.Taken) // As long as there isn't a piece two spaces ahead
                    {
                        proposedMoves.Add(new Move() { X = X, Y = Y - 2 }); // Add the move
                    }
                }

                if (Board[X, Y - 1] == null || Board[X, Y - 1].Piece.Taken) // As long as there isn't a piece one space ahead
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - 1 }); // Add the move
                }

                if (X < 7)
                {
                    if (Board[X + 1, Y - 1] != null && !Board[X + 1, Y - 1].Piece.Taken &&
                        Board[X + 1, Y - 1].Piece.Color == Color.Black)
                    {
                        proposedMoves.Add(new Move() { X = X + 1, Y = Y - 1, Takeable = true });
                    }
                }

                if (X > 0)
                {
                    if (Board[X - 1, Y - 1] != null && !Board[X - 1, Y - 1].Piece.Taken &&
                        Board[X - 1, Y - 1].Piece.Color == Color.Black)
                    {
                        proposedMoves.Add(new Move() { X = X - 1, Y = Y - 1, Takeable = true });
                    }
                }
            }
            if (Color == Color.Black) // Black pawns can only move down the board
            {
                if (Y == 0) // Check if the black pawn reached the other side of the board
                {
                    Board[X, Y].Piece = new Rook() { X = X, Y = Y }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                    return proposedMoves;
                }
                else if (Y == 1) // Pawns can move two spaces on their first move
                {
                    if (Board[X, Y + 2] == null || Board[X, Y + 2].Piece.Taken) // As long as there isn't a piece two spaces ahead
                    {
                        proposedMoves.Add(new Move() { X = X, Y = Y + 2 }); // Add the move
                    }
                }

                if (Board[X, Y + 1] == null || Board[X, Y + 1].Piece.Taken) // As long as there isn't a piece one space ahead
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + 1 }); // Add the move
                }

                if (X < 7)
                {
                    if (Board[X + 1, Y + 1] != null && !Board[X + 1, Y + 1].Piece.Taken &&
                        Board[X + 1, Y + 1].Piece.Color == Color.White)
                    {
                        proposedMoves.Add(new Move() { X = X + 1, Y = Y + 1, Takeable = true });
                    }
                }

                if (X > 0)
                {
                    if (Board[X - 1, Y + 1] != null && !Board[X - 1, Y + 1].Piece.Taken &&
                        Board[X - 1, Y + 1].Piece.Color == Color.White)
                    {
                        proposedMoves.Add(new Move() { X = X - 1, Y = Y + 1, Takeable = true });
                    }
                }

            }
            return proposedMoves;
        }
    }

    public class Rook : Piece
    {
        public Rook()
        {
            Board = new Cell[8, 8];
        }
        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();

            #region Upward iteration
            for (int height = 1; height <= Y; height++)
            {
                if (Board[X, Y - height] == null || Board[X, Y - height].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - height });
                }
                else if (Board[X, Y - height].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - height, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Downward iteration
            for (int height = 1; height <= 7 - Y; height++)
            {
                if (Board[X, Y + height] == null || Board[X, Y + height].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + height });
                }
                else if (Board[X, Y + height].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + height, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Leftward iteration
            for (int width = 1; width <= X; width++)
            {
                if (Board[X - width, Y] == null || Board[X - width, Y].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X - width, Y = Y });
                }
                else if (Board[X - width, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X - width, Y = Y, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Rightward iteration
            for (int width = 1; width <= 7 - X; width++)
            {
                if (Board[X + width, Y] == null || Board[X + width, Y].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X + width, Y = Y });
                }
                else if (Board[X + width, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X + width, Y = Y, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            return proposedMoves;
        }
    }

    public class King : Piece
    {
        public King()
        {
            Board = new Cell[8, 8];
        }

        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();

            if (Y > 0)
            {
                if (Board[X, Y - 1] == null || Board[X, Y - 1].Piece.Taken) // Check space above is empty
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - 1 });
                }
                else if (Board[X, Y - 1].Piece.Color != Color) // If not empty, if the piece of an opposite color
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - 1, Takeable = true });
                }
            }

            if (Y < 7)
            {
                if (Board[X, Y + 1] == null || Board[X, Y + 1].Piece.Taken) // Check space below is empty
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + 1 });
                }
                else if (Board[X, Y + 1].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + 1, Takeable = true });
                }
            }

            if (X > 0)
            {
                if (Board[X - 1, Y] == null || Board[X - 1, Y].Piece.Taken) // Check space to left is empty
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y });
                }
                else if (Board[X - 1, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y, Takeable = true });
                }
            }

            if (X < 7)
            {
                if (Board[X + 1, Y] == null || Board[X + 1, Y].Piece.Taken) // Check space to right is empty
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y });
                }
                else if (Board[X + 1, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y, Takeable = true });
                }
            }

            if (X > 0 && Y > 0)
            {
                if (Board[X - 1, Y - 1] == null || Board[X - 1, Y - 1].Piece.Taken) // Check up left is empty
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y - 1 });
                }
                else if (Board[X - 1, Y - 1].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y - 1, Takeable = true });
                }
            }

            if (X > 0 && Y < 7)
            {
                if (Board[X - 1, Y + 1] == null || Board[X - 1, Y + 1].Piece.Taken) // Check down left is empty
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y + 1 });
                }
                else if (Board[X - 1, Y + 1].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X - 1, Y = Y + 1, Takeable = true });
                }
            }

            if (X < 7 && Y > 0)
            {
                if (Board[X + 1, Y - 1] == null || Board[X + 1, Y - 1].Piece.Taken) // Check up right is empty
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y - 1 });
                }
                else if (Board[X + 1, Y - 1].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y - 1, Takeable = true });
                }
            }

            if (X < 7 && Y < 7)
            {
                if (Board[X + 1, Y + 1] == null || Board[X + 1, Y + 1].Piece.Taken) // Check down right is empty
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y + 1 });
                }
                else if (Board[X + 1, Y + 1].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X + 1, Y = Y + 1, Takeable = true });
                }
            }
            return proposedMoves;
        }
    }

    public class Bishop : Piece
    {
        public Bishop()
        {
            Board = new Cell[8, 8];
        }

        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();

            #region Up left iteration
            if (X <= Y)
            {
                for (int width = 1; width <= X; width++)
                {
                    if (Board[X - width, Y - width] == null || Board[X - width, Y - width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y - width });
                    }
                    else if (Board[X - width, Y - width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y - width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= Y; height++)
                {
                    if (Board[X - height, Y - height] == null || Board[X - height, Y - height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y - height });
                    }
                    else if (Board[X - height, Y - height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y - height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Up right iteration
            if (X <= 7 - Y)
            {
                for (int height = 1; height <= Y; height++)
                {
                    if (Board[X + height, Y - height] == null || Board[X + height, Y - height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y - height });
                    }
                    else if (Board[X + height, Y - height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y - height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int width = 1; width <= 7 - X; width++)
                {
                    if (Board[X + width, Y - width] == null || Board[X + width, Y - width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y - width });
                    }
                    else if (Board[X + width, Y - width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y - width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Down right iteration
            if (X >= Y)
            {
                for (int width = 1; width <= 7 - X; width++)
                {
                    if (Board[X + width, Y + width] == null || Board[X + width, Y + width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y + width });
                    }
                    else if (Board[X + width, Y + width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y + width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= 7 - Y; height++)
                {
                    if (Board[X + height, Y + height] == null || Board[X + height, Y + height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y + height });
                    }
                    else if (Board[X + height, Y + height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y + height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Down left iteration
            if (X <= 7 - Y)
            {
                for (int width = 1; width <= X; width++)
                {
                    if (Board[X - width, Y + width] == null || Board[X - width, Y + width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y + width });
                    }
                    else if (Board[X - width, Y + width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y + width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= 7 - Y; height++)
                {
                    if (Board[X - height, Y + height] == null || Board[X - height, Y + height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y + height });
                    }
                    else if (Board[X - height, Y + height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y + height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion

            return proposedMoves;
        }
    }

    public class Queen : Piece
    {
        public Queen()
        {
            Board = new Cell[8, 8];
        }

        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();

            #region Upward iteration
            for (int height = 1; height <= Y; height++)
            {
                if (Board[X, Y - height] == null || Board[X, Y - height].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - height });
                }
                else if (Board[X, Y - height].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y - height, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Downward iteration
            for (int height = 1; height <= 7 - Y; height++)
            {
                if (Board[X, Y + height] == null || Board[X, Y + height].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + height });
                }
                else if (Board[X, Y + height].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X, Y = Y + height, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Leftward iteration
            for (int width = 1; width <= X; width++)
            {
                if (Board[X - width, Y] == null || Board[X - width, Y].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X - width, Y = Y });
                }
                else if (Board[X - width, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X - width, Y = Y, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Rightward iteration
            for (int width = 1; width <= 7 - X; width++)
            {
                if (Board[X + width, Y] == null || Board[X + width, Y].Piece.Taken)
                {
                    proposedMoves.Add(new Move() { X = X + width, Y = Y });
                }
                else if (Board[X + width, Y].Piece.Color != Color)
                {
                    proposedMoves.Add(new Move() { X = X + width, Y = Y, Takeable = true });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion

            #region Up left iteration
            if (X <= Y)
            {
                for (int width = 1; width <= X; width++)
                {
                    if (Board[X - width, Y - width] == null || Board[X - width, Y - width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y - width });
                    }
                    else if (Board[X - width, Y - width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y - width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= Y; height++)
                {
                    if (Board[X - height, Y - height] == null || Board[X - height, Y - height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y - height });
                    }
                    else if (Board[X - height, Y - height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y - height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Up right iteration
            if (X <= 7 - Y)
            {
                for (int height = 1; height <= Y; height++)
                {
                    if (Board[X + height, Y - height] == null || Board[X + height, Y - height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y - height });
                    }
                    else if (Board[X + height, Y - height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y - height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int width = 1; width <= 7 - X; width++)
                {
                    if (Board[X + width, Y - width] == null || Board[X + width, Y - width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y - width });
                    }
                    else if (Board[X + width, Y - width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y - width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Down right iteration
            if (X >= Y)
            {
                for (int width = 1; width <= 7 - X; width++)
                {
                    if (Board[X + width, Y + width] == null || Board[X + width, Y + width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y + width });
                    }
                    else if (Board[X + width, Y + width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + width, Y = Y + width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= 7 - Y; height++)
                {
                    if (Board[X + height, Y + height] == null || Board[X + height, Y + height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y + height });
                    }
                    else if (Board[X + height, Y + height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + height, Y = Y + height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            #region Down left iteration
            if (X <= 7 - Y)
            {
                for (int width = 1; width <= X; width++)
                {
                    if (Board[X - width, Y + width] == null || Board[X - width, Y + width].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y + width });
                    }
                    else if (Board[X - width, Y + width].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - width, Y = Y + width, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int height = 1; height <= 7 - Y; height++)
                {
                    if (Board[X - height, Y + height] == null || Board[X - height, Y + height].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y + height });
                    }
                    else if (Board[X - height, Y + height].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X - height, Y = Y + height, Takeable = true });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion

            return proposedMoves;
        }
    }

    public class Knight : Piece
    {
        public Knight()
        {
            Board = new Cell[8, 8];
        }

        public override List<Move> GetMoves()
        {
            var proposedMoves = new List<Move>();
            for (int i = 1; i <= 2; i++)
            {
                if (X + i - 3 > -1 && X + i - 3 <= 7 &&
                    Y + i > -1 && Y + i <= 7)
                {
                    if (Board[X + i - 3, Y + i] == null || Board[X + i - 3, Y + i].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + i - 3, Y = Y + i });
                    }
                    else if (Board[X + i - 3, Y + i].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + i - 3, Y = Y + i, Takeable = true });
                    }
                }


                if (X + i - 3 > -1 && X + i - 3 <= 7 &&
                    Y + i * -1 > -1 && Y + i * -1 <= 7)
                {
                    if (Board[X + i - 3, Y + i * -1] == null || Board[X + i - 3, Y + i * -1].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + i - 3, Y = Y + i * -1 });
                    }
                    else if (Board[X + i - 3, Y + i * -1].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + i - 3, Y = Y + i * -1, Takeable = true });
                    }
                }

                if (X + i > -1 && X + i <= 7 &&
                    Y + i - 3 > -1 && Y + i - 3 <= 7)
                {
                    if (Board[X + i, Y + i - 3] == null || Board[X + i, Y + i - 3].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + i, Y = Y + i - 3 });
                    }
                    else if (Board[X + i, Y + i - 3].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + i, Y = Y + i - 3, Takeable = true });
                    }
                }

                if (X + i > -1 && X + i <= 7 &&
                    Y + (i - 3) * -1 > -1 && Y + (i - 3) * -1 <= 7)
                {
                    if (Board[X + i, Y + (i - 3) * -1] == null || Board[X + i, Y + (i - 3) * -1].Piece.Taken)
                    {
                        proposedMoves.Add(new Move() { X = X + i, Y = Y + (i - 3) * -1 });
                    }
                    else if (Board[X + i, Y + (i - 3) * -1].Piece.Color != Color)
                    {
                        proposedMoves.Add(new Move() { X = X + i, Y = Y + (i - 3) * -1, Takeable = true });
                    }
                }
            }
            return proposedMoves;
        }
    }

    public class PieceFactory
    {
        public Piece NewPiece(PieceIndex index, int x, int y)
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

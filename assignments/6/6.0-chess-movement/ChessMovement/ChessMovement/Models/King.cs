using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
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
}

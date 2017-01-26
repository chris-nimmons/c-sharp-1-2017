using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
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
}

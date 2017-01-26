using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
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
}

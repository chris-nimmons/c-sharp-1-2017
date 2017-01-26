using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
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
}

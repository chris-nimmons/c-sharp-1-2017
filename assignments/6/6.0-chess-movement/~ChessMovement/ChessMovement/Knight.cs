using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
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
}

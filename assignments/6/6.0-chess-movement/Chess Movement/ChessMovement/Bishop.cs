using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Bishop : Piece
    {
        public Bishop()
        {
            Letter = 'B';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 8; i++)
            {
                if (X - i >= 0)
                {

                    var move = new Move() { X = X - i, Y = Y + i };
                    if (IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X + i, Y = Y + i };
                    if(IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X + i, Y = Y - i };
                    if(IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X - i, Y = Y - i };
                    if(IsOnBoard(move))
                    {
                        moves.Add(move);
                    }
                }
            }
            return moves;
        }
    }
}

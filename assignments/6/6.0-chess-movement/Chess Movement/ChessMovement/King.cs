using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class King : Piece
    {
        public King()
        {
            Letter = 'K';
            Visible = true;
        }

        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    var move = new Move() { X = X - row, Y = Y + col };
                    if (IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X + row, Y = Y + col };
                    if(IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X + row, Y = Y - col };
                    if(IsOnBoard(move))
                    {
                        moves.Add(move);
                    }

                    move = new Move() { X = X - row, Y = Y - col };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Queen : Piece
    {
        public Queen()
        {
            Letter = 'Q';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 7; i++)
            {
                if (X - i >= 0)
                {
                    moves.Add(new Move() { X = X - i, Y = Y + i });
                    moves.Add(new Move() { X = X - 1, Y = Y });
                    moves.Add(new Move() { X = X, Y = Y + 1 });
                    moves.Add(new Move() { X = X + i, Y = Y + i });

                }
                if (Y - 1 >= 0)
                {
                    moves.Add(new Move() { X = X + i, Y = Y - i });
                    moves.Add(new Move() { X = X - i, Y = Y - i });
                    moves.Add(new Move() { X = X + i, Y = Y });
                    moves.Add(new Move() { X = X, Y = Y - 1 });
                }
           
            }
            return moves;
        }

    }
}


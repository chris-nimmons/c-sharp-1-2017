using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public class King : Piece, IRenderable
    {
        public King()
        {
            Index = 'K';
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();

            for (int col = X; col <= X + 1; col++)
            {
                moves.Add(new Move { X = X + 1, Y = Y });

                moves.Add(new Move { X = col + X, Y = Y });

                moves.Add(new Move { X = col, Y = Y + 1 });

                moves.Add(new Move { X = col, Y = Y - 1 });

                moves.Add(new Move { X = col - 1, Y = Y = Y });

                moves.Add(new Move { X = col - 1, Y = Y - 1 });

                moves.Add(new Move { X = col - 1, Y = Y + 1 });

            }

            return moves;

        }


    }

}

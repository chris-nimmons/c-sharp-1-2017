using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
   public class Bishop : Piece, IRenderable
    {
        public Bishop()
        {
            Index = 'B';

        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();


            for (int i = 0; i <= 7; i++)
            {

                moves.Add(new Move { X = X, Y = Y });

                moves.Add(new Move { X = X - i, Y = Y + i });

                moves.Add(new Move { X = X + i, Y = Y - i });

                moves.Add(new Move { X = X + i, Y = Y + i });

                moves.Add(new Move { X = X - i, Y = Y - i });

            }
            return moves;
        }
    }
}

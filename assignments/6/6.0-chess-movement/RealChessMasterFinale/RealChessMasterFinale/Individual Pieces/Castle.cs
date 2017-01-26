using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public class Castle : Piece, IRenderable
    {
        public Castle()
        {
            Index = 'C';
        }


        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();


            for (int col = X; col <= X + 7; col++)
            {
                moves.Add(new Move { X = col, Y = Y });

                moves.Add(new Move { X = col - 7, Y = Y });

                for (int row = Y; row <= Y + 7; row++)
                {
                    moves.Add(new Move { X = X, Y = row });

                    moves.Add(new Move { X = X, Y = row - 7 });
                }
            }
            return moves;
        }

    }
}

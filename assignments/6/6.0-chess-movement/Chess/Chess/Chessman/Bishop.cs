using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class Bishop : Piece, IRenderable
    {
        public Bishop()
        {
            Index = 'B';
            Squares = 6;
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();

         

            for (int a = 0; a < Squares; a++)
            {
                moves.Add(new Move() { X = X + a, Y = Y + a });

                moves.Add(new Move() { X = X - a, Y = Y - a });

                moves.Add(new Move() { X = X + a, Y = Y - a });

                moves.Add(new Move() { X = X - a, Y = Y + a });

            }
            return moves;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class Pawn : Piece, IRenderable
    {
        public Pawn()
        {
            Index = 'P';
            Squares = 1;
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();
         

            moves.Add(new Move() { X = X, Y = Y });
            moves.Add(new Move() { X = X, Y = Y + Squares });

            return moves;
        }
    }
}


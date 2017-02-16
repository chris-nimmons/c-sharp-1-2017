using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Pawn : Piece, IRenderable
    {
        public Pawn()
        {
            Letter = 'P';
            Visible = true;
        }

        public override List<Move> Moves()
        {
            var moves = new List<Move>();
            {
                moves.Add(new Move() { X = X, Y = Y + 1 });
            }
            return moves;
        }
    }
}




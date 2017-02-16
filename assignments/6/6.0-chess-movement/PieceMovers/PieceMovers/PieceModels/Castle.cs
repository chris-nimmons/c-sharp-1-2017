using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Castle : Piece, IRenderable
    {
        public Castle()
        {
            Letter = 'C';
            Visible = true;
        }

        public override List<Move> Moves()
        {
            var moves = new List<Move>();
            for (int i = 1; i < 8; i++)
            {
                moves.Add(new Move() { X = X, Y = Y - i });
                moves.Add(new Move() { X = X, Y = Y + i });
                moves.Add(new Move() { X = X + i, Y = Y });
                moves.Add(new Move() { X = X - i, Y = Y });
            }
            return moves;
        }
    }
}




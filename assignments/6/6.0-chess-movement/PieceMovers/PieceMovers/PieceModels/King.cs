using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class King : Piece, IRenderable
    {
        public King()
        {
            Letter = 'K';
            Visible = true;
        }

        public override List<Move> Moves()
        {
            var moves = new List<Move>();
            {
                moves.Add(new Move() { X = X, Y = Y + 1 });
                moves.Add(new Move() { X = X, Y = Y - 1 });
                moves.Add(new Move() { X = X + 1, Y = Y });
                moves.Add(new Move() { X = X - 1, Y = Y });
                moves.Add(new Move() { X = X + 1, Y = Y + 1 });
                moves.Add(new Move() { X = X - 1, Y = Y - 1 });
                moves.Add(new Move() { X = X - 1, Y = Y + 1 });
                moves.Add(new Move() { X = X + 1, Y = Y - 1 });
            }
            return moves;
        }
    }
}




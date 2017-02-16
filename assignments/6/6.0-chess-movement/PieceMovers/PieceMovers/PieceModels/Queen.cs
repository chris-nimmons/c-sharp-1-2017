using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Queen : Piece, IRenderable
    {
        public Queen()
        {
            Letter = 'Q';
            Visible = true;
        }

        public override List<Move> Moves()
        {
            var moves = new List<Move>();
            for (int i = 1; i < 8; i++)
            {
                moves.Add(new Move() { X = X - i, Y = Y - i });
                moves.Add(new Move() { X = X - i, Y = Y + i });
                moves.Add(new Move() { X = X + i, Y = Y + i });
                moves.Add(new Move() { X = X + i, Y = Y + i });
                moves.Add(new Move() { X = X + i, Y = Y - i });
                moves.Add(new Move() { X = X - i, Y = Y });
                moves.Add(new Move() { X = X + i, Y = Y });
                moves.Add(new Move() { X = X, Y = Y + i });
                moves.Add(new Move() { X = X, Y = Y - i });
            }
            return moves;
        }
    }
}




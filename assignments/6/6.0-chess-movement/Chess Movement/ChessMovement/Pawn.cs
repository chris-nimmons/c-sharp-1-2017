using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Pawn : Piece
    {
        public Pawn()
        {
            Letter = 'P';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 2; i++)
            {
                moves.Add(new Move() { X = X, Y = Y + i });
            }
            return moves;
        }
    }
}

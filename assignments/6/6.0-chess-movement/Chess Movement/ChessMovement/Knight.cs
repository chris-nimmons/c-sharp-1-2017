using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Knight : Piece
    {
        public Knight()
        {
            Letter = 'N';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 7; i++)
            {
                moves.Add(new Move() { X = X + 1, Y = Y });
                moves.Add(new Move() { X = X + 3, Y = Y });
                moves.Add(new Move() { X = X + 4, Y = Y + 1 });
                moves.Add(new Move() { X = X + 4, Y = Y + 3 });
                moves.Add(new Move() { X = X + 3, Y = Y + 4 });
                moves.Add(new Move() { X = X + 1, Y = Y + 4 });
                moves.Add(new Move() { X = X, Y = Y + 3 });
                moves.Add(new Move() { X = X, Y = Y + 1 });
            }
            return moves;
        }
    }
}

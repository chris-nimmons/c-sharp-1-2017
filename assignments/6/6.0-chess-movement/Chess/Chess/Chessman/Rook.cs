using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class Rook : Piece, IRenderable
    {
        public Rook()
        {
            Index = 'R';
            Squares = 7;
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();
           

            for (int c = 0; c < X + Squares; c++)
            {
                moves.Add(new Move() { X = X, Y = Y });

                moves.Add(new Move() { X = c, Y = Y });

                for (int r = 0; r < Y + Squares; r++)
                {
                    moves.Add(new Move() { X = X, Y = Y });

                    moves.Add(new Move() { X = X, Y = r });
                }
            }
            return moves;
        }
    }
}

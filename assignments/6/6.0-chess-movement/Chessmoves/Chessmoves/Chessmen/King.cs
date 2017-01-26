using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class King : Piece, IRenderable
    {
        public King()
        {
           Index = 'K';
            Squares = 1;
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();

            moves.Add(new Move());

            for (int i = 0; i < X + Squares; i++)
            {
              
                    moves.Add(new Move() { X = X + Squares, Y = Y });

                    moves.Add(new Move() { X = X - Squares, Y = Y });

                    moves.Add(new Move() { X = X, Y = Y + Squares });

                    moves.Add(new Move() { X = X, Y = Y - Squares });

                    moves.Add(new Move() { X = X - Squares, Y = Y + Squares });

                   moves.Add(new Move() { X = X + Squares, Y = Y - Squares });

                    moves.Add(new Move() { X = X + Squares, Y = Y + Squares });

                    moves.Add(new Move() { X = X - Squares, Y = Y - Squares });
                
            }
            return moves;
        }
    }
}

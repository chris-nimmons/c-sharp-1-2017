using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class Knight : Piece, IRenderable
    {
        public Knight()
        {
            Index = 'N';
            Squares = 3;
        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();

           

            moves.Add(new Move() { X = X, Y = Y });

            moves.Add(new Move() { X = X + 2, Y = Y + 1 });

            moves.Add(new Move() { X = X - 2, Y = Y - 1 });

            moves.Add(new Move() { X = X - 2, Y = Y + 1 });

            moves.Add(new Move() { X = X + 2, Y = Y - 1 });

            moves.Add(new Move() { X = X + 1, Y = Y + 2 });

            moves.Add(new Move() { X = X - 1, Y = Y + 2 });
            
            moves.Add(new Move() { X = X - 1, Y = Y - 2 });

            moves.Add(new Move() { X = X + 1, Y = Y - 2 });

            return moves;
        }
    }
}


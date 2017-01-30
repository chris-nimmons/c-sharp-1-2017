using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public class Pawn : Piece, IRenderable
    {
        public Pawn()
        {
            Index = 'P';

        }

        public override List<Move> GetMoves()
        {
            var moves = new List<Move>();
            var moveAllow = new List<Move>();
            // var move = new Move();

            //move.X = X;
            //move.Y = Y;
            //moves.Add(new Move());

            moves.Add(new Move() { X = X, Y = Y });

            //move.X = X;
            //move.Y = Y + 1;               this is the same as below
            //moves.Add(move);

            moves.Add(new Move() { X = X, Y = Y + 1 });

            return moves;


        }
    }
}

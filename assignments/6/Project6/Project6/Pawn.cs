using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Pawn : Piece
    {

        public Pawn()
        {
            Letter = 'P';
        }

        public override List<Move> GetMoves()
        {

            var allowedMoves = new List<Move>();


            if (this.Color == PieceType.White)
            {
                allowedMoves.Add(new Move
                {
                    X = X,
                    Y = Y + 1
                });
            }
            else if (this.Color == PieceType.Black)
            {
                allowedMoves.Add(new Move
                {
                    X = X,
                    Y = Y - 1
                });
            }

            return allowedMoves;

        }
    }
} 
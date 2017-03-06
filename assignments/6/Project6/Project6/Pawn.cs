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

        public override bool IsMoveAllowed(List<Piece> board, Cursor toPosition)
        {

            if (toPosition.X == this.X && toPosition.Y == this.Y)
            {
                return true;
            }

            if ((this.X == toPosition.X) && (Math.Abs(this.Y - toPosition.Y) > 1))
            {
                return false;
            }

            if (this.Color == PieceType.White && this.X == toPosition.X && this.Y < toPosition.Y)
            {
                return true;
            }

            if (this.Color == PieceType.Black && this.X == toPosition.X && this.Y > toPosition.Y)
            {
                return true;
            }

            return false;

        }
    }
} 
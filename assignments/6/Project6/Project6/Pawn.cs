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

        public override PieceType Color { get; set; }

        public override char Letter { get; set; }


        public override bool Visible { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }


        //public override List<Move> GetMoves()
        //{

        //     var allowedCursors = new List<Move>();


        //    if (this.Color == PieceType.White)
        //    {
        //        allowedCursors.Add(new Move
        //        {
        //            X = X,
        //            Y = Y + 1
        //        });
        //    }
        //    else if (this.Color == PieceType.Black)
        //    {
        //        allowedCursors.Add(new Move
        //        {
        //            X = X,
        //            Y = Y - 1
        //        });
        //    }

        //    return allowedCursors;

        //}

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Castle : Piece
    {
        public Castle()
        {
            Letter = 'C';
        }
        public override PieceType Color { get; set; }

        public override char Letter { get; set; }


        public override bool Visible { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }


        //public override List<Move> GetMoves()
        //{

        //    var allowedCursors = new List<Move>();

        //    if (this.Color == PieceType.White)
        //    {
        //        for (int i = 0; i < 8; i++)
        //        {
        //            allowedCursors.Add(new Move
        //            {
        //                X = X,
        //                Y = Y - i
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X + i,
        //                Y = Y
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X,
        //                Y = Y + i
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X - i,
        //                Y = Y
        //            });
        //        }

        //    }
        //    else if (this.Color == PieceType.Black)
        //    {
        //        for (int i = 0; i < 8; i++)
        //        {
        //            allowedCursors.Add(new Move
        //            {
        //                X = X,
        //                Y = Y - i
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X + i,
        //                Y = Y
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X,
        //                Y = Y + i
        //            });
        //            allowedCursors.Add(new Move
        //            {
        //                X = X - i,
        //                Y = Y
        //            });
        //        }
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
                return true;
            }

            if ((this.Y == toPosition.Y) && (Math.Abs(this.X - toPosition.X) > 1))
            {
                return true;
            }

            if (this.Color == PieceType.White && this.X == toPosition.X && this.Y < toPosition.Y)
            {
                return true;
            }
            if (this.Color == PieceType.White && this.Y == toPosition.Y && this.X < toPosition.X)
            {
                return true;
            }

            if (this.Color == PieceType.Black && this.X == toPosition.X && this.Y > toPosition.Y)
            {
                return true;
            }
            if (this.Color == PieceType.White && this.Y == toPosition.Y && this.X > toPosition.X)
            {
                return true;
            }


            return false;


        }
    }
}
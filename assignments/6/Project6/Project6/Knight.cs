using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Knight : Piece
    {
        public Knight()
        {
            Letter = 'N';
        }
  

        //public override List<Move> GetMoves()
        //{

        //    var allowedCursors = new List<Move>();
        //    if (this.Color == PieceType.White)
        //    {
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y + 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y + 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y -2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 2 ,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 2,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y - 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 2,
        //            Y = Y + 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 2,
        //            Y = Y + 1
        //        });


        //    }
        //    else if (this.Color == PieceType.Black)
        //    {
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y + 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y + 2
        //        });
        //        allowedCursors.Add(new Move

        //        {
        //            X = X + 1,
        //            Y = Y - 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 2,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 2,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y - 2
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 2,
        //            Y = Y + 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 2,
        //            Y = Y + 1
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

            if (toPosition.X == this.X + 1 && toPosition.Y == this.Y + 2)
            {
                return true;
            }

            if (toPosition.X == this.X - 1 && toPosition.Y == this.Y + 2)
            {
                return true;
            }

            if (toPosition.X == this.X + 2 && toPosition.Y == this.Y - 1)
            {
                return true;
            }

            if (toPosition.X == this.X - 2 && toPosition.Y == this.Y - 1)
            {
                return true;
            }

            if (toPosition.X == this.X - 1 && toPosition.Y == this.Y - 2)
            {
                return true;
            }

            if (toPosition.X == this.X - 2 && toPosition.Y == this.Y - 1)
            {
                return true;
            }

            if (toPosition.X == this.X - 2 && toPosition.Y == this.Y + 1)
            {
                return true;
            }

            if (toPosition.X == this.X + 2 && toPosition.Y == this.Y + 1)
            {
                return true;
            }

            if (toPosition.X == this.X - 2 && toPosition.Y == this.Y + 1)
            {
                return true;
            }

            if ((this.X == toPosition.X) && (Math.Abs(this.Y - toPosition.Y) > 1))
            {
                return false;
            }


            if ((this.Y == toPosition.Y) && (Math.Abs(this.X - toPosition.X) > 1))
            {
                return false;
            }


            if (this.Color == PieceType.White && this.Y == toPosition.Y && this.X < toPosition.X)
            {
                return true;
            }

            if (this.Color == PieceType.Black && this.X == toPosition.X && this.X > toPosition.X)
            {
                return true;
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
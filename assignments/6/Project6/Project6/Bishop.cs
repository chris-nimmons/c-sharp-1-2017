using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Bishop : Piece
    {
        public Bishop()
        {
            Letter = 'B';
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
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y + 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y + 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y - 1
        //        });
        //    }
        //    else if (this.Color == PieceType.Black)
        //    {
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y + 1 
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X -1,
        //            Y = Y - 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X - 1,
        //            Y = Y + 1
        //        });
        //        allowedCursors.Add(new Move
        //        {
        //            X = X + 1,
        //            Y = Y - 1
        //        });

        //    }
        //    return allowedCursors;

        //}

        private bool ValidateMove(
                                Cursor tempCursor,
                                Cursor toPosition,
                                ref List<Piece> board,
                                int edgeX,
                                int edgeY,
                                Func<Cursor, Cursor> direction)
        {

            tempCursor.X = this.X;
            tempCursor.Y = this.Y;

            while (true)
            {


                tempCursor = direction(tempCursor);

                // Match to position so move is good.
                if (tempCursor.X == toPosition.X && tempCursor.Y == toPosition.Y)
                {
                    return true;
                }

                // Partial match means move was not diagonal.
                if (tempCursor.X == toPosition.X || tempCursor.Y == toPosition.Y)
                {
                    return false;
                }

                // Check if we have a piece in the way.
                if (board.Where(p => p.X == tempCursor.X && p.Y == tempCursor.Y).Any())
                {
                    return false;
                }

                // Reached top edge.
                if (tempCursor.X == edgeX || tempCursor.Y == edgeY)
                {
                    break;
                }

            }

            return false;

        }

        public override bool IsMoveAllowed(List<Piece> board, Cursor toPosition)
        {

            // Check if the piece did not move at all which is allowed. This will happen for all
            // pieces.
            if (toPosition.X == this.X && toPosition.Y == this.Y)
            {
                return true;
            }

            // Check if bishop did a diagonal move of any type. A proper move for a diagonal line
            // will have a to position were both the x and y are different when compared to the current
            // piece position x and y.
            if (this.X == toPosition.X || this.Y == toPosition.Y)
            {
                return false;
            }

            // Now check general direction of the bishop by checking the to position to the
            // pieces current position.

            var tempCursor = new Cursor();

            // To left and up.
            if (toPosition.X < this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X - 1;
                    cursor.Y = cursor.Y - 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 0, direction);

            }

            // To left and down.
            if (toPosition.X < this.X && toPosition.Y > this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X - 1;
                    cursor.Y = cursor.Y + 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 8, direction);

            }

            // To right and down.
            if (toPosition.X > this.X && toPosition.Y > this.Y)
            {


                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X + 1;
                    cursor.Y = cursor.Y + 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 8, 8, direction);

            }

            // To right and up.
            if (toPosition.X > this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X + 1;
                    cursor.Y = cursor.Y - 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 8, 0, direction);

            }

            return false;

        }
    }
}
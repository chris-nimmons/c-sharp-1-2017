using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Queen : Piece
    {
        public Queen()
        {
            Letter = 'Q';
        }


        public override List<Move> GetMoves()
        {

            var allowedMoves = new List<Move>();

            if (this.Color == PieceType.White)
            {
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y
                });
                allowedMoves.Add(new Move
                {
                    X = X,
                    Y = Y + 1
                });
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y + 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y
                });
                allowedMoves.Add(new Move
                {
                    X = X,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y + 1
                });
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y - 1
                });

            }


            else if (this.Color == PieceType.Black)
            {
                for (int i = 0; i < 8; i++)
                {
                    allowedMoves.Add(new Move
                    {
                        X = X + 1,
                        Y = Y
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y + 1
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X + 1,
                        Y = Y + 1
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X - 1,
                        Y = Y
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y - 1
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X - 1,
                        Y = Y - 1
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X + 1,
                        Y = Y - 1
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X - i,
                        Y = Y + i
                    });
                }


            }
            return allowedMoves;

        }

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

                if (tempCursor.X == toPosition.X && tempCursor.Y == toPosition.Y)
                {
                    return true;
                }

                if (tempCursor.X == toPosition.X || tempCursor.Y == toPosition.Y)
                {
                    return false;
                }

                // Check if we have a piece in the way.
                if (board.Where(p => p.X == tempCursor.X && p.Y == tempCursor.Y).Any())
                {
                    return false;
                }


                if (tempCursor.X == edgeX || tempCursor.Y == edgeY)
                {
                    break;
                }

            }

            return false;

        }

        public override bool IsMoveAllowed(List<Piece> board, Cursor toPosition)
        {


            if (toPosition.X == this.X && toPosition.Y == this.Y)
            {
                return true;
            }

            //diagonal
            if (this.X == toPosition.X || this.Y == toPosition.Y)
            {
                return true;
            }


            var tempCursor = new Cursor();



            if (toPosition.X < this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X + 1;
                    cursor.Y = cursor.Y;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 0, direction);

            }

            if (toPosition.X < this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X - 1;
                    cursor.Y = cursor.Y;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 0, direction);

            }

            if (toPosition.X < this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X;
                    cursor.Y = cursor.Y + 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 0, direction);

            }

            if (toPosition.X < this.X && toPosition.Y < this.Y)
            {

                var direction = new Func<Cursor, Cursor>((cursor) =>
                {
                    cursor.X = cursor.X;
                    cursor.Y = cursor.Y - 1;
                    return cursor;
                });

                return ValidateMove(tempCursor, toPosition, ref board, 0, 0, direction);

            }

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


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


        public override List<Move> GetMoves()
        {

            var allowedMoves = new List<Move>();
            if (this.Color == PieceType.White)
            {
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y + 2
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y + 2
                });
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y - 2
                });
                allowedMoves.Add(new Move
                {
                    X = X + 2,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 2,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y - 2
                });
                allowedMoves.Add(new Move
                {
                    X = X + 2,
                    Y = Y + 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 2,
                    Y = Y + 1
                });


            }
            else if (this.Color == PieceType.Black)
            {
                allowedMoves.Add(new Move
                {
                    X = X + 1,
                    Y = Y + 2
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y + 2
                });
                allowedMoves.Add(new Move

                {
                    X = X + 1,
                    Y = Y - 2
                });
                allowedMoves.Add(new Move
                {
                    X = X + 2,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 2,
                    Y = Y - 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 1,
                    Y = Y - 2
                });
                allowedMoves.Add(new Move
                {
                    X = X + 2,
                    Y = Y + 1
                });
                allowedMoves.Add(new Move
                {
                    X = X - 2,
                    Y = Y + 1
                });

            }
            return allowedMoves;

        }
    }
}
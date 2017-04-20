﻿using System;
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

        public override List<Move> GetMoves()
        {

            var allowedMoves = new List<Move>();

            if (this.Color == PieceType.White)
            {
                for (int i = 0; i < 8; i++)
                {
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y - i
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X + i,
                        Y = Y
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y + i
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X - i,
                        Y = Y
                    });
                }

            }
            else if (this.Color == PieceType.Black)
            {
                for (int i = 0; i < 8; i++)
                {
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y - i
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X + i,
                        Y = Y
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X,
                        Y = Y + i
                    });
                    allowedMoves.Add(new Move
                    {
                        X = X - i,
                        Y = Y
                    });
                }
            }

            return allowedMoves;

        }
    }
}
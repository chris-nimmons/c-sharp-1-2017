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


        public override List<Move> GetMoves()
        {

            var allowedCursors = new List<Move>();

            if (this.Color == PieceType.White)
            {
                for (int i = 0; i < 8; i++)
                {
                    allowedCursors.Add(new Move
                    {
                        X = X,
                        Y = Y - i
                    });
                    allowedCursors.Add(new Move
                    {
                        X = X + i,
                        Y = Y
                    });
                    allowedCursors.Add(new Move
                    {
                        X = X,
                        Y = Y + i
                    });
                    allowedCursors.Add(new Move
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
                    allowedCursors.Add(new Move
                    {
                        X = X,
                        Y = Y - i
                    });
                    allowedCursors.Add(new Move
                    {
                        X = X + i,
                        Y = Y
                    });
                    allowedCursors.Add(new Move
                    {
                        X = X,
                        Y = Y + i
                    });
                    allowedCursors.Add(new Move
                    {
                        X = X - i,
                        Y = Y
                    });
                }
            }

            return allowedCursors;

        }
    }
}
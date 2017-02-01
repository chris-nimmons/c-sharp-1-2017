using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class King : Piece
    {
        public King()
        {
            Letter = 'K';
        }

        public override PieceType Color { get; set; }

        public override char Letter { get; set; }


        public override bool Visible { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }


        public override Cursor[] GetMoves()
        {

            var allowedCursors = new List<Cursor>();
            if (this.Color == PieceType.White)
            {
                allowedCursors.Add(new Cursor
                {
                    X = X + 1,
                    Y = Y
                });
                allowedCursors.Add(new Cursor
                {
                    X = X,
                    Y = Y + 1
                });
                allowedCursors.Add(new Cursor
                {
                    X = X + 1,
                    Y = Y + 1
                });
                allowedCursors.Add(new Cursor
                {
                    X = X - 1,
                    Y = Y
                });
                allowedCursors.Add(new Cursor
                {
                    X = X,
                    Y = Y - 1
                });
            }
            else if (this.Color == PieceType.Black)
            {
                allowedCursors.Add(new Cursor
                {
                    X = X + 1,
                    Y = Y
                });
                allowedCursors.Add(new Cursor
                {
                    X = X,
                    Y = Y + 1
                });
                allowedCursors.Add(new Cursor
                {
                    X = X + 1,
                    Y = Y + 1
                });
                allowedCursors.Add(new Cursor
                {
                    X = X - 1,
                    Y = Y
                });
                allowedCursors.Add(new Cursor
                {
                    X = X,
                    Y = Y + 1
                });

            }
            return allowedCursors.ToArray();

        }
    }
}

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
            if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = 1,
                    Y = -1
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = -1,
                    Y = -1
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = -1,
                    Y = 1
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = 0,
                    Y = 1
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = 1,
                    Y = 0
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = -1,
                    Y = 0
                });
            }
                        else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = -1,
                    Y = 1
                });
            }
            else if (Color.Equals(0) || Color.Equals(1))
            {
                allowedCursors.Add(new Cursor
                {
                    X = 0,
                    Y = -1
                });
            }

            return allowedCursors.ToArray();

        }
    }
}

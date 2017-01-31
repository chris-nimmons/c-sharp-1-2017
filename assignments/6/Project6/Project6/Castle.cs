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


        public override Cursor[] GetMoves()
        {

            var allowedCursors = new List<Cursor>();
            if (Color.Equals(0))
            {
                allowedCursors.Add(new Cursor
                {
                    X = 0,
                    Y = 0
                });
            }
            else
            {
                allowedCursors.Add(new Cursor
                {
                    X = 0,
                    Y = 0
                });

            }
            return allowedCursors.ToArray();

        }
    }
}
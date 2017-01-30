using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public abstract class Piece
    {
        public abstract string[] GetMoves();

        public abstract int X { get; set; }
        public abstract int Y { get; set; }

        public abstract char Letter { get; set; }
        public abstract bool Visible { get; set; }

        public abstract Enum Color { get; set; }

        public Piece()
        {
            Visible = true;

        }

    }
}

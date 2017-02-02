using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public abstract class Piece
    {

        public enum PieceType
        {
            White = 0,
            Black = 1
        }

        public abstract List<Move> GetMoves();

        public abstract int X { get; set; }
        public abstract int Y { get; set; }

        public abstract char Letter { get; set; }
        public abstract bool Visible { get; set; }

        public abstract PieceType Color { get; set; }

        public Piece()
        {
            Visible = true;

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public abstract class ChessPiece : IRenderable
    {
        public bool Visible { get; set; }
        public char Letter { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public abstract List<Move> GetMoves();

    }
}

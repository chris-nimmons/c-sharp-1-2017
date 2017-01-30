using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public abstract class Piece : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Squares { get; set; }
        public char Index { get; set; }
        public bool Visible { get; set; }

        public abstract List<Move> GetMoves();
    }


}

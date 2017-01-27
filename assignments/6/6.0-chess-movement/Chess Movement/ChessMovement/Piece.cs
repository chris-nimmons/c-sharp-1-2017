using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public abstract class Piece : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }
        public bool Visible { get; set; }
        public int Index { get; set; }

        public abstract List<IRenderable> GetMoves();

     
    }
}

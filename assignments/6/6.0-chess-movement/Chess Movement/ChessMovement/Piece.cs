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

        public bool IsOnBoard(Move move)
        {
            if (move.X < 0)
                return false;
            if (move.Y < 0)
                return false;
            if (move.X >= 8)
                return false;
            if (move.Y >= 8)
                return false;

            return true;
        }

    }
}

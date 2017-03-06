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


        public abstract bool IsMoveAllowed(List<Piece> board, Cursor toPosition);

        public abstract List<Move> GetMoves();

        public int X { get; set; }
        public int Y { get; set; }

        public char Letter { get; set; }
        public bool Visible { get; set; }

        public PieceType Color { get; set; }

        public Piece()
        {
            Visible = true;
        }


    }
}
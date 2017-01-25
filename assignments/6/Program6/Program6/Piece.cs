using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program6
{
    class Piece : IRenderable
    {
        public List<Queen> Queens { get; set; }
        public List<King> Kings { get; set; }
        public List<Pawn> Pawns { get; set; }
        public List<Bishop> Bishops { get; set; }
        public List<Knight> Kinghts { get; set; }
        public List<Castle> Castles { get; set; }

        public class PieceProperties
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
        public class Cursor
        {
            public int X { get; set; }
            public int Y { get; set; }

        }
    }
}

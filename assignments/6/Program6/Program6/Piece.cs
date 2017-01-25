using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program6
{
    class Piece : IRenderable
    {


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

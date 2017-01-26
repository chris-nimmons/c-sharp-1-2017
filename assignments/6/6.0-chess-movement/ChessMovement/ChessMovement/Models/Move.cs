using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Takeable { get; set; }
        public PieceID ID { get; set; }
    }
}

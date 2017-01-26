using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PieceID PieceId { get; set; }
        public Color Color { get
            {
                if ((int)PieceId > 15)
                {
                    return Color.White;
                }
                else
                {
                    return Color.Black;
                }
            } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public abstract class Piece : IRenderable
    {
        public bool Visible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }
        public abstract List<Move> Moves();

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Letter);
        }
    }
}



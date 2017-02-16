using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Move : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public char Letter { get; set; }
        public Move()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Visible = true;
            Letter = '*';
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Pawn : Piece
    {

        public Pawn()
        {
            Letter = 'P';
        }

        public override PieceType Color { get; set; }

        public override char Letter { get; set; }


        public override bool Visible { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }


        public override string[] GetMoves()
        {
            var cursor = new Cursor();
            Console.SetCursorPosition(X, Y);
            return (X,Y);
           
        }

    }
}
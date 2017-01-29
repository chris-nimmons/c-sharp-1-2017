using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Knight : Piece
    {
        public Knight()
        {
            Letter = 'N';
        }
        public override char Letter { get; set; }


        public override bool Visible { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }


        public override string[] GetMoves()
        {
            throw new NotImplementedException();
        }
    }
}
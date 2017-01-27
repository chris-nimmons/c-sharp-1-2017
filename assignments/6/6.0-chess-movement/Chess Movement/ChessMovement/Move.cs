using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Move : Cursor, IRenderable
    {

        public int Index { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public char Letter { get; set; }

        public Move()
        {
            Visible = true;
            Letter = '#';
        }

        public List<IRenderable> GetMoves()
        {
            throw new NotImplementedException();
        }
    }
}

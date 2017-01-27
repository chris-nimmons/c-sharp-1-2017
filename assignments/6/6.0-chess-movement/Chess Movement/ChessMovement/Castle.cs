using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Castle : Piece
    {
        public Castle()
        {
            Letter = 'C';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 7; i++)
            {
                moves.Add(new Move() { X = X + i, Y = Y});
                moves.Add(new Move() { X = X, Y = Y + i });

                //if (X < 0 = 0)
                //{

                //}
                //if( Y < 0 = 0)
                //{

                // }
            
           }
            return moves;
        }
    }
}

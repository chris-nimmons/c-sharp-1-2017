using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class King : Piece
    {
        public King()
        {
            Letter = 'K';
            Visible = true;
        }

        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (X - row >= 0)
                    {
                    moves.Add(new Move() { X = X - row, Y = Y + col });
                    moves.Add(new Move() { X = X + row, Y = Y + col });
                    }
                    if (Y - col >= 0)
                    {
                    moves.Add(new Move() { X = X + row, Y = Y - col });
                    moves.Add(new Move() { X = X - row, Y = Y - col });
                    }

                }
            }
            return moves;
        }

    }
}

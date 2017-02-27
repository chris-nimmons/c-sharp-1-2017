using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Knight : Piece
    {
        public Knight()
        {
            Letter = 'N';
            Visible = true;
        }


        public override List<IRenderable> GetMoves()
        {
            var moves = new List<IRenderable>();

            for (int i = 0; i < 7; i++)
            {
                var move = new Move() { X = X + 1, Y = Y + 2 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X + 2, Y = Y + 1 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X + 2, Y = Y - 1 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X + 1, Y = Y - 2 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X - 1, Y = Y + 2 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X - 2, Y = Y + 1 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X - 2, Y = Y - 1 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
                move = new Move() { X = X - 1, Y = Y - 2 };
                if (IsOnBoard(move))
                {
                    moves.Add(move);
                }
            }
            return moves;
        }
    }
}

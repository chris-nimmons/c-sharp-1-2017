using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    class Castle : Piece
    {
        public List<Move> Getmoves()
        {
            var moves = new List<Move>();

            //horizontal right
            moves.Add(new Move() { X = X + 1, Y = Y + 0 });
            moves.Add(new Move() { X = X + 2, Y = Y + 0 });
            moves.Add(new Move() { X = X + 3, Y = Y + 0 });
            moves.Add(new Move() { X = X + 4, Y = Y + 0 });
            moves.Add(new Move() { X = X + 5, Y = Y + 0 });
            moves.Add(new Move() { X = X + 6, Y = Y + 0 });
            moves.Add(new Move() { X = X + 7, Y = Y + 0 });

            //horizontal left
            moves.Add(new Move() { X = X + 1, Y = Y - 1 });
            moves.Add(new Move() { X = X + 2, Y = Y - 2 });
            moves.Add(new Move() { X = X + 3, Y = Y - 3 });
            moves.Add(new Move() { X = X + 4, Y = Y - 4 });
            moves.Add(new Move() { X = X + 5, Y = Y - 5 });
            moves.Add(new Move() { X = X + 6, Y = Y - 6 });
            moves.Add(new Move() { X = X + 7, Y = Y - 7 });

            //vertical down
            moves.Add(new Move() { X = X + 0, Y = Y - 1 });
            moves.Add(new Move() { X = X + 0, Y = Y - 2 });
            moves.Add(new Move() { X = X + 0, Y = Y - 3 });
            moves.Add(new Move() { X = X + 0, Y = Y - 4 });
            moves.Add(new Move() { X = X + 0, Y = Y - 5 });
            moves.Add(new Move() { X = X + 0, Y = Y - 6 });
            moves.Add(new Move() { X = X + 0, Y = Y - 7 });

            //vertical down
            moves.Add(new Move() { X = X + 0, Y = Y + 1 });
            moves.Add(new Move() { X = X + 0, Y = Y + 2 });
            moves.Add(new Move() { X = X + 0, Y = Y + 3 });
            moves.Add(new Move() { X = X + 0, Y = Y + 4 });
            moves.Add(new Move() { X = X + 0, Y = Y + 5 });
            moves.Add(new Move() { X = X + 0, Y = Y + 6 });
            moves.Add(new Move() { X = X + 0, Y = Y + 7 });


            return moves;
        }
        public void startRender()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('C');
        }
        public void Render()
        {
            
            Console.Write('C');
        }

    }
}

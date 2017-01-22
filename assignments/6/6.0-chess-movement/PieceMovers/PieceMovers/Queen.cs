using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Queen : Piece
    {
        public List<Move> Getmoves()
        {
            var moves = new List<Move>();

            //diagonal up left
            moves.Add(new Move() { X = X - 1, Y = Y - 1 });
            moves.Add(new Move() { X = X - 2, Y = Y - 2 });
            moves.Add(new Move() { X = X - 3, Y = Y - 3 });
            moves.Add(new Move() { X = X - 4, Y = Y - 4 });
            moves.Add(new Move() { X = X - 5, Y = Y - 5 });
            moves.Add(new Move() { X = X - 6, Y = Y - 6 });
            moves.Add(new Move() { X = X - 7, Y = Y - 7 });

            //diagnal down left
            moves.Add(new Move() { X = X + 1, Y = Y - 1 });
            moves.Add(new Move() { X = X + 2, Y = Y - 2 });
            moves.Add(new Move() { X = X + 3, Y = Y - 3 });
            moves.Add(new Move() { X = X + 4, Y = Y - 4 });
            moves.Add(new Move() { X = X + 5, Y = Y - 5 });
            moves.Add(new Move() { X = X + 6, Y = Y - 6 });
            moves.Add(new Move() { X = X + 7, Y = Y - 7 });

            //diagonal down right
            moves.Add(new Move() { X = X + 1, Y = Y + 1 });
            moves.Add(new Move() { X = X + 2, Y = Y + 2 });
            moves.Add(new Move() { X = X + 3, Y = Y + 3 });
            moves.Add(new Move() { X = X + 4, Y = Y + 4 });
            moves.Add(new Move() { X = X + 5, Y = Y + 5 });
            moves.Add(new Move() { X = X + 6, Y = Y + 6 });
            moves.Add(new Move() { X = X + 7, Y = Y + 7 });

            //diagnal up right
            moves.Add(new Move() { X = X - 1, Y = Y + 1 });
            moves.Add(new Move() { X = X - 2, Y = Y + 2 });
            moves.Add(new Move() { X = X - 3, Y = Y + 3 });
            moves.Add(new Move() { X = X - 4, Y = Y + 4 });
            moves.Add(new Move() { X = X - 5, Y = Y + 5 });
            moves.Add(new Move() { X = X - 6, Y = Y + 6 });
            moves.Add(new Move() { X = X - 7, Y = Y + 7 });


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
            Console.SetCursorPosition(4, 0);
            Console.Write("Q");
        }
        public void Render()
        {
            Console.Write('Q');
        }
        

    }
}



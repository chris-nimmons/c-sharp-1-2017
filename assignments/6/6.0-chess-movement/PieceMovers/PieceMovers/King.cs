using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    class King : Piece
    {

        public List<Move> Getmoves()
        {
            var moves = new List<Move>();
            moves.Add(new Move() { X = X + 0, Y = Y + 1 });
            moves.Add(new Move() { X = X + 0, Y = Y - 1 });
            moves.Add(new Move() { X = X + 1, Y = Y + 0 });
            moves.Add(new Move() { X = X - 1, Y = Y + 0 });
            //diagonal
            moves.Add(new Move() { X = X + 1, Y = Y + 1 });
            moves.Add(new Move() { X = X - 1, Y = Y - 1 });
            moves.Add(new Move() { X = X - 1, Y = Y + 1 });
            moves.Add(new Move() { X = X + 1, Y = Y - 1 });

            return moves;
        }
        public void startRender()
        {
            Console.SetCursorPosition(5, 0);
            Console.Write("K");
        }

        public void Render()
        {
            letter = 'K';
            Console.Write('K');

        }


    }
}

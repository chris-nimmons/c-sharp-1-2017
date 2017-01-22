using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    class Knight : Piece
    {

        public List<Move> Getmoves()
        {
            var moves = new List<Move>();
            moves.Add(new Move() { X = X - 1, Y = Y - 2 });
            moves.Add(new Move() { X = X - 2, Y = Y - 1 });
            moves.Add(new Move() { X = X - 2, Y = Y + 1 });
            moves.Add(new Move() { X = X - 1, Y = Y + 2 });
            moves.Add(new Move() { X = X + 1, Y = Y - 2 });
            moves.Add(new Move() { X = X + 2, Y = Y - 1 });
            moves.Add(new Move() { X = X + 1, Y = Y + 2 });
            moves.Add(new Move() { X = X + 2, Y = Y + 1 });

            return moves;
        }
        public void startRender()
        {
            Console.SetCursorPosition(2, 0);
            Console.Write("N");
        }

        public void Render()
        {
            letter = 'N';
            Console.Write('N');

        }


    }
}

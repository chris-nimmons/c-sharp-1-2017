using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    class Pawn : Piece
    {
       
        public List<Move> Getmoves()
        {
            var moves = new List<Move>();
            moves.Add(new Move() { X = X+0, Y = Y + 1 });

            return moves;
        }
        public void startRender()
        {
            Console.SetCursorPosition(1, 1);
            Console.Write("P");
        }

        public void Render()
        {
            letter = 'P';
            Console.Write('P');

        }


    }
}

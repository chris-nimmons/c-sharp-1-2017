using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    public class Pawn : Piece
    {
        public void Render()
        {
            X = 7;
            Y = 1;
            canMove = 1;
            Index = 'P';
            Console.SetCursorPosition(X, Y);
            Console.Write(Index);
        }

        public List<Move> GetMoves()
        {
            var moves = new List<Move>();
            {
                Console.SetCursorPosition(X, Y + 1);
                Console.Write("#");
            }
            return moves;

        }
    }
}

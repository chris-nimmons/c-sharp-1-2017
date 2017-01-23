using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
   public class Bishop : Piece
    {
        public void Render()
        {
            X = 2;
            Y = 0;
            canMove = 8;
            Index = 'B';
            Console.SetCursorPosition(X, Y);
            Console.Write(Index);

        }

        public List<Move> GetMoves()
        {
            var moves = new List<Move>();

            for (int i = 0; i <= canMove; i++)
            {

                Console.SetCursorPosition(X, Y);
                Console.Write("#");

                Console.SetCursorPosition(X - i, Y + i);
                Console.Write("#");

                Console.SetCursorPosition(X + i, Y - i);
                Console.Write("#");

                Console.SetCursorPosition(X + i, Y + i);
                Console.Write("#");

                Console.SetCursorPosition(X - i, Y - i);
                Console.Write("#");

            }
            return moves;
        }
    }
}

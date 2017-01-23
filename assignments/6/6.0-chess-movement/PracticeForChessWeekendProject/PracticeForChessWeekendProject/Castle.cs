using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    public class Castle : Piece
    {
        public void Render()
        {
            X = 0;
            Y = 0;
            canMove = 8;
            Index = 'C';
            Console.SetCursorPosition(X, Y);
            Console.Write(Index);

        }

        public List<Move> GetMoves()
        {
            var moves = new List<Move>();

            for (int col = X; col <= X + canMove; col++)
            {

                Console.SetCursorPosition(col, Y);
                Console.Write("#");

                Console.SetCursorPosition(col - canMove, Y);
                Console.Write("#");
                for (int row = Y; row <= Y + canMove; row++)
                {
                    Console.SetCursorPosition(X, row);
                    Console.Write("#");

                    Console.SetCursorPosition(X, row - canMove);
                    Console.Write("#");

                }
            }
            return moves;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    public class Queen : Piece
    {
        public void Render()
        {
            X = 3;
            Y = 0;
            canMove = 8;
            Index = 'Q';
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
            
            foreach (var move in moves)
            {
                if (X < 0)
                {
                    X = 0;
                }

                else if (Y < 0)
                {
                    Y = 0;
                }


               else if (X > 7)
                {
                    X = 7;
                }

                else if (Y > 7)
                {
                    Y = 7;
                }
            }
        }
    }
}

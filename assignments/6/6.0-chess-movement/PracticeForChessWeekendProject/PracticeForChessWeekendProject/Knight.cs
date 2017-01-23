using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    public class Knight : Piece
    {
        public void Render()
        {
            X = 1;
            Y = 0;
            Index = 'N';
            Console.SetCursorPosition(X, Y);
            Console.Write(Index);
        }

        public List<Move> GetMoves()
        {
            var moves = new List<Move>();
            {
                Console.SetCursorPosition(X + 2, Y + 1);
                Console.Write("#");

                Console.SetCursorPosition(X + 2, Y - 1);
                Console.Write("#");

                Console.SetCursorPosition(X - 2, Y + 1);
                Console.Write("#");

                Console.SetCursorPosition(X - 2, Y - 1);
                Console.Write("#");

                Console.SetCursorPosition(X + 1, Y + 2);
                Console.Write("#");

                Console.SetCursorPosition(X + 1, Y - 2);
                Console.Write("#");

                Console.SetCursorPosition(X - 1, Y - 2);
                Console.Write("#");

                Console.SetCursorPosition(X - 1, Y + 2);
                Console.Write("#");
            }
            return moves;

        }
    }
}

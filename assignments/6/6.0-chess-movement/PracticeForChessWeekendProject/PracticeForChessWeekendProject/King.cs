using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    public class King : Piece
    {
        public void Render()
        {
            X = 4;
            Y = 0;
            canMove = 1;
            Index = 'K';
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

                    Console.SetCursorPosition(col, Y + canMove);
                    Console.Write("#");

                    Console.SetCursorPosition(col, Y - canMove);
                    Console.Write("#");

                    Console.SetCursorPosition(col - canMove, Y);
                    Console.Write("#");

                    Console.SetCursorPosition(col - canMove, Y - canMove);
                    Console.Write("#");

                    Console.SetCursorPosition(col - canMove, Y + canMove);
                    Console.Write("#");
                }

                return moves;
            }




        }

    }





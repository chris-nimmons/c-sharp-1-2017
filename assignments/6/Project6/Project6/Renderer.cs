using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Renderer
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void Render(List<Piece> pieces, List<Move> moves)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Visible)
                {
                    Console.SetCursorPosition(piece.X, piece.Y);
                    Console.Write(piece.Letter);
                }
                else
                {
                    
                }


            }
                //DONE: go through each of the moves and write out a character to represent the move.  
            foreach(var move in moves)
            {
                
                if ( move.X < 8 && move.Y < 8)
                {
                    if (move.X >= 0 && move.Y >= 0)
                    {
                        Console.SetCursorPosition(move.X, move.Y);
                        Console.Write("X");
                    }

                }
                

            }

        }
    }
}

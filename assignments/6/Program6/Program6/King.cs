using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program6
{
    class King : Piece
    {
        public void GetMoves()
        {

            int Width = 20;
            int Height = 20;

            for (int x = 1; x < Width; x++)
            {
                for (int y = 1; y < Height; y++)
                {
                    if (y == 1 || y == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("K");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("");
                    }

                }
            }
            Console.ReadLine();
        }

    }


}
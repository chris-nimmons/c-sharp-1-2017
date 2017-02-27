using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public void GetMoves()
        {

        }
        public void Render()
        {
            for (int col = X; col < Length + Y; col++)
            {
                for (int row = Y; row < Length + X; row++)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write("x");
                    //Console.SetCursorPosition(1, 1);
                    //Console.Write("o");
                    //Console.SetCursorPosition(0, 4);
                    //Console.WriteLine("King");
                }

            }
            Console.ReadLine();
            Console.Clear();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Knight : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public void Render()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(1, 0);
                Console.Write("x");
                Console.SetCursorPosition(3, 0);
                Console.Write("x");
                Console.SetCursorPosition(4, 1);
                Console.Write("x");
                Console.SetCursorPosition(4, 3);
                Console.Write("x");
                Console.SetCursorPosition(3, 4);
                Console.Write("x");
                Console.SetCursorPosition(1, 4);
                Console.Write("x");
                Console.SetCursorPosition(0, 3);
                Console.Write("x");
                Console.SetCursorPosition(0, 1);
                Console.Write("x");
                Console.SetCursorPosition(2, 2);
                Console.Write("o");
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Knight");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}

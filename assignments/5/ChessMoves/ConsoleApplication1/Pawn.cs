using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pawn
    {
        public void Render()
        {
            Console.SetCursorPosition(7, 7);
            Console.Write("---Pawn---");
            Console.SetCursorPosition(10, 9);
            Console.Write("X");
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }
    }
}

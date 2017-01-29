using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Board
    {
        public Board()
        {
            int width = 8;
            int length = 8;
            for(int i = 0; i <width-1; i++)
            {
                for(int j = 0; j < length-1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("X");
                }
                Console.Write(" ");
            }
        }

    }
}

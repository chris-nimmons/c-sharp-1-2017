using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    class Pawn
    {
        static void Main(string[] args)
        {
            for (X = 1; X < 9; X++)
            {
                for (Y = 1; Y < 9; Y++)
                {
                    if (X == 4 && Y == 1)
                    {
                        Console.Write("Q");
                        Console.ReadLine();
                    }
                    else if (X == 6 && Y == 1)
                    {
                        Console.Write("Q");
                        Console.ReadLine();
                    }
                    else if (X == 4 && Y == 9)
                    {
                        Console.Write("Q");
                        Console.ReadLine();
                    }
                    else if (X == 6 && Y == 9)
                    {
                        Console.Write("Q");
                        Console.ReadLine();
                    }
                }
            }


            Console.ReadLine();
        }
    }
}



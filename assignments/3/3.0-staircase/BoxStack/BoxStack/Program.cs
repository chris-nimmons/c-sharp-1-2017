using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxStack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            The Graveyard of Failed Ideas:
            Console.WriteLine("   X");
            Console.WriteLine("  XX");
            Console.WriteLine(" XXX");
            Console.WriteLine("XXXX");
            

            Console.ReadLine();
            */

            //string stackX = "";
            //char addX = 'X';
            //char addSpace = '-';
            //string s = "XXXX";
            //Console.WriteLine(stackX);
            //Console.WriteLine(AddX);


            int rows = 10;
            int cols = 10;
          

            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int spaces = cols - row;
                    if (col + 1 >= spaces)
                    {

                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    
                }
                Console.WriteLine();
            }

           
            Console.ReadLine();
        }
    }
}

//Think about it like a grid
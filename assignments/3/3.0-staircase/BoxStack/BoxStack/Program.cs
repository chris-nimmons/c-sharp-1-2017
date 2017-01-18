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


            int totalRows = 10;
            int totalCols = 10;
          

            
            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < totalCols; currentCol++)
                {
                    // TThink of it like a grid or matrix
                    //   0 1 2
                    // 0! ! !X!
                    // 1! !X!X!
                    // 2!X!X!X!
                                        
                    int spaces = totalCols - currentRow;   
                    if (currentCol + 1 >= spaces)
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
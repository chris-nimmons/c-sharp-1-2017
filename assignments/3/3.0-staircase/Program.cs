using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staircasetest
{
    public class Staircase
    {
        static void Main(string[] args)
        {
            //string[] X = {"     X","    XX","   XXX","  XXXX"," XXXXX","XXXXXX"};
            //foreach (string value in X)
            //{
            //    Console.WriteLine(value);

            //}
            //Console.ReadLine();

            string stairCase = "";
            string spaces = " ";
            char addX = 'X';
            int stairs = 6;

            for (int x = 0; x < stairs; x++)
            {
                for (int y = x; y < stairs - 1; y++)
                {
                    Console.Write(spaces);
                }
                stairCase = stairCase + addX;
                Console.WriteLine(stairCase);
            }

            
    


           
            Console.ReadLine();
            
        }

      
                    
               
    
        
    }
}

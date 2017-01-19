using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";
            string[] sentence = one.Split(' ');

            foreach (string word in sentence)
            {
                if (word == "tchoffo")
                {
                    Console.Write("like ");
                    Console.ReadKey(true);
                }
                else if (word == "pow")
                {
                    Console.Write("owe ");
                    Console.ReadKey(true);
                }
                else if (word == "pa")
                {
                    Console.Write("acorn ");
                    Console.ReadKey(true);
                }
                else if (word == "Ring")
                {
                    Console.Write("me ");
                    Console.ReadKey(true);
                }
                else if (word == "joff")
                {
                    Console.Write("and ");
                    Console.ReadKey(true);
                }
                else if (word == "ho")
                {
                    Console.Write("I ");
                    Console.ReadKey(true);
                }
                else if (word == "hatee")
                {
                    Console.Write("dont ");
                    Console.ReadKey(true);
                }
                else if (word == "ding")
                {
                    Console.Write("a ");
                    Console.ReadKey(true);
                }
                else if (word == "dingeringeding")
                {
                    Console.Write("squirrels ");
                    Console.ReadKey(true);
                }
                else if (word == "wa")
                {
                    Console.Write("you ");
                    Console.ReadKey(true);
                }
                else if (word == "tchoff")
                {
                    Console.Write("new ");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.Write("");
                }
            }
        }
    }
}

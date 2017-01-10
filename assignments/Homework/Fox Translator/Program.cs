using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string sentence = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";

            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                if(word == "wa")
                {
                    Console.WriteLine("you");
                }
                else if(word == "pow")
                {
                    Console.WriteLine("owe");
                }
                else if(word == "ring")
                {
                    Console.WriteLine("me");
                }
                else if(word == "ding")
                {
                    Console.WriteLine("a");
                }
                else if(word == "tchoff")
                {
                    Console.WriteLine("new");
                }
                else if(word == "pa")
                {
                    Console.WriteLine("acorn");
                }
                else if(word == "joff")
                {
                    Console.WriteLine("and");
                }
                else if(word == "ho")
                {
                    Console.WriteLine("I");
                }
                else if(word == "hatee")
                {
                    Console.WriteLine("dont");
                }
                else if(word == "tchoffo")
                {
                    Console.WriteLine("like");
                }
                else if(word == "dingeringeding")
                {
                    Console.WriteLine("squirrels");
                }
               
            }
            Console.ReadLine();
            
        }
    }
}

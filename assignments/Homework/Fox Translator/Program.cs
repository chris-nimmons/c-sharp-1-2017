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
                    Console.Write("You ");
                }
                else if(word == "pow")
                {
                    Console.Write("owe ");
                }
                else if(word == "ring")
                {
                    Console.Write("me ");
                }
                else if(word == "ding")
                {
                    Console.Write("a ");
                }
                else if(word == "tchoff")
                {
                    Console.Write("new ");
                }
                else if(word == "pa")
                {
                    Console.Write("acorn ");
                }
                else if(word == "joff")
                {
                    Console.Write("and ");
                }
                else if(word == "ho")
                {
                    Console.Write("I ");
                }
                else if(word == "hatee")
                {
                    Console.Write("dont ");
                }
                else if(word == "tchoffo")
                {
                    Console.Write("like ");
                }
                else if(word == "dingeringeding")
                {
                    Console.Write("squirrels.");
                }
               
            }
            Console.ReadLine();
            
        }
    }
}

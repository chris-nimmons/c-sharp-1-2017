using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Fox
{
    public class FoxSay
    {
        public void FoxTranslate()
        {
            string fox = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";

            string[] sentenceArray = fox.Split(' ');

            foreach (string word in sentenceArray)
            {

                if (word == "wa")
                {
                    Console.WriteLine("you");
                    Console.ReadLine();
                }
                else if (word == "pow")
                {
                    Console.WriteLine("owe");
                    Console.ReadLine();
                }
                else if (word == "tchoffo")
                {
                    Console.WriteLine("like");
                    Console.ReadLine();
                }
                else if (word == "pa")
                {
                    Console.WriteLine("acorn");
                    Console.ReadLine();
                }
                else if (word == "joff")
                {
                    Console.WriteLine("and");
                    Console.ReadLine();
                }
                else if (word == "ho")
                {
                    Console.WriteLine("I");
                    Console.ReadLine();
                }
                else if (word == "ring")
                {
                    Console.WriteLine("me");
                    Console.ReadLine();
                }
                else if (word == "hatee")
                {
                    Console.WriteLine("don't");
                    Console.ReadLine();
                }
                else if (word == "ding")
                {
                    Console.WriteLine("a");
                    Console.ReadLine();
                }
                else if (word == "dingeringeding")
                {
                    Console.WriteLine("squirrels");
                    Console.ReadLine();
                }
                else if (word == "tchoff")
                {
                    Console.WriteLine("new");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("wololo");
                    Console.ReadLine();
                }                

            }
        }
    }
}

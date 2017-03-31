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
            string humanSpeak = "";
            string[] sentenceArray = fox.Split(' ');

            foreach (string word in sentenceArray)
            {

                if (word == "wa")
                {
                    humanSpeak += "you";
                    
                }
                else if (word == "pow")
                {
                    humanSpeak += "owe";
                   
                }
                else if (word == "tchoffo")
                {
                    humanSpeak += "like";
                    
                }
                else if (word == "pa")
                {
                    humanSpeak += "acorn";
                    
                }
                else if (word == "joff")
                {
                    humanSpeak += ("and");
                   
                }
                else if (word == "ho")
                {
                    humanSpeak += "I";
                    
                }
                else if (word == "ring")
                {
                    humanSpeak += "me";
                    
                }
                else if (word == "hatee")
                {
                    humanSpeak += ("don't");
                    
                }
                else if (word == "ding")
                {
                    humanSpeak += "a";
                   
                }
                else if (word == "dingeringeding")
                {
                    humanSpeak += "squirrels";
                   
                }
                else if (word == "tchoff")
                {
                    humanSpeak += "new";
                }
                else
                {
                    Console.WriteLine("wololo");
                    Console.ReadLine();
                }
                


            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxTranslator.Translator;


namespace FoxTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";
            Translators translate = new Translators();
            string translation = translate.Translate(sentence);
            Console.WriteLine(translation);
            Console.ReadLine();



            //string[] words = sentence.Split(' ');
            //string translatedSentence = string.Empty;

            //foreach (string word in words)
            //{
            //    if (word == "wa")
            //    {
            //        translatedSentence += "you ";
            //    }
            //    else if (word == "pow")
            //    {
            //        translatedSentence += "owe ";
            //    }
            //    else if (word == "ring")
            //    {
            //        translatedSentence += "me ";
            //    }
            //    else if (word == "ding")
            //    {
            //        translatedSentence += "a ";
            //    }
            //    else if (word == "tchoff")
            //    {
            //        translatedSentence += "new ";
            //    }
            //    else if (word == "pa")
            //    {
            //        translatedSentence += "acorn ";
            //    }
            //    else if (word == "joff")
            //    { 
            //        translatedSentence += "and ";
            //    }
            //    else if (word == "ho")
            //    {
            //        translatedSentence += "I ";
            //    }
            //    else if (word == "hatee")
            //    {
            //        translatedSentence += "don't ";
            //    }
            //    else if (word == "tchoffo")
            //    {
            //        translatedSentence += "like ";
            //    }
            //    else if (word == "dingeringeding")
            //    {
            //        translatedSentence += "squirrels!";
            //    }

            //}
            //Console.WriteLine(translation);
            //Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Take a list of words, replace them from another list based on the word in question

namespace FoxTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";
            Translaters translate = new Translaters();
            string translation = translate.Translate(sentence);
            Console.WriteLine(translation);
        }
    }
}



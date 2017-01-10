using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string foxSpeak = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding";
            Translator translator = new FoxTranslator.Translator();
            Console.WriteLine(translator.AlternativeTranslate(foxSpeak));
            Console.ReadLine();
        }
    }
}

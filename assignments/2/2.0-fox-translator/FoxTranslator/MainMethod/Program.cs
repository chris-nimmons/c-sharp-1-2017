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
            Console.WriteLine("I'm going to translate:\n{0}\nfrom foxspeak to human speak.", foxSpeak);
            Translator translator = new FoxTranslator.Translator();
            string humanSpeak = translator.Translate(foxSpeak);
            Console.WriteLine(humanSpeak);
            Console.ReadLine();
        }
    }
}

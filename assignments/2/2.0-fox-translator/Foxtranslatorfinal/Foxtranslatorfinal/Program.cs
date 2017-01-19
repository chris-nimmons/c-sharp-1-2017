using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxtranslatorfinal
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding.";



            Translators translate = new Translators();
            string translation = translate.Translate(sentence);
            
            Console.WriteLine(translation);

            Console.ReadLine();




        }
    }
}

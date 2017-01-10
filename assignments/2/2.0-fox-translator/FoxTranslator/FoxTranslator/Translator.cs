using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxTranslator.translator  
{
    public class Translators

    {
        public string Translate(string sentence)
        {
         

            string[] words = sentence.Split(' ');
            string translatedSentence = string.Empty;
          
            
            foreach (string word in words)
            {
                if (word == "wa")
                {
                    translatedSentence += "you ";
                }

                else if (word == "pow")
                {
                    translatedSentence += "owe ";
                }

                else if (word == "ring")
                {
                    translatedSentence += "me ";
                }

                else if (word == "ding")
                {
                    translatedSentence += "a ";
                }

                else if (word == "tchoff")
                {
                    translatedSentence += "like ";
                }

                else if (word == "pa")
                {
                    translatedSentence += "acorn ";
                }

                else if (word == "joff")
                {
                    translatedSentence += "and ";
                }

                else if (word == "ho")
                {
                    translatedSentence += "I ";
                }

                else if (word == "hatee")
                {
                    translatedSentence += "dont ";
                }

                else if (word == "tchoffo")
                {
                    translatedSentence += "like ";
                }

                else if (word == "dingeringeding.")
                {
                    translatedSentence += "squirrles ";
                }
                

        
                }
            return translatedSentence;
        
            }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxTranslator
{
    class Translator
    {
        private string[] foxWords;
        private string[] humanWords;

        public Translator()
        {
            foxWords = new string[11] 
                { "tchoffo", "pow", "pa", "joff", "ho", "ring", "hatee", "ding", "dingeringeding", "wa", "tchoff" };
            humanWords = new string[11]
                { "like", "owe", "acorn", "and", "I", "me", "dont", "a", "squirrels", "you", "new" };
        }

        public string Translate(string foxSpeak)
        {
            //Split sentence
            //Create new string[] same size as Splitsentence
            //Iterate each word and find foxWords index
            //Replace humanSpeak index w/ humanword
            string[] foxSpeakSplitted = foxSpeak.Split();
            string[] humanSpeak = new string[foxSpeak.Length];
            for (int sentenceIndex = 0; sentenceIndex < foxSpeakSplitted.Length; sentenceIndex++)
            {
                for (int translatorIndex = 0; translatorIndex < foxWords.Length; translatorIndex++)
                {
                    if (foxSpeakSplitted[sentenceIndex] == foxWords[translatorIndex])
                    {
                        humanSpeak[sentenceIndex] = humanWords[translatorIndex];
                    }
                }
            }

            string translatedSentence = "";

            foreach (string word in humanSpeak)
            {
                translatedSentence += word + " ";
            }

            return translatedSentence;
        }
    }
}

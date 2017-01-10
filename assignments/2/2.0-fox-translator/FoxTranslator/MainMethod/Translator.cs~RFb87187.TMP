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

        public string AlternativeTranslate(string foxSpeak)
        {
            string[] foxSpeakSplitted = foxSpeak.Split();
            string humanSpeak = "";
            foreach (string word in foxSpeakSplitted)
            {
                if (word == "tchoffo")
                {
                    humanSpeak += "like ";
                }
                else if (word == "pow")
                {
                    humanSpeak += "owe ";
                }
                else if (word == "pa")
                {
                    humanSpeak += "acorn ";
                }
                else if (word == "joff")
                {
                    humanSpeak += "and ";
                }
                else if (word == "ho")
                {
                    humanSpeak += "I ";
                }
                else if (word == "ring")
                {
                    humanSpeak += "me ";
                }
                else if (word == "hatee")
                {
                    humanSpeak += "dont ";
                }
                else if (word == "ding")
                {
                    humanSpeak += "a ";
                }
                else if (word == "dingeringeding")
                {
                    humanSpeak += "squirrels ";
                }
                else if (word == "wa")
                {
                    humanSpeak += "you ";
                }
                else if (word == "tchoff")
                {
                    humanSpeak += "new ";
                }
            }

            return humanSpeak;
        }

        public string Translate(string foxSpeak)
        {
            //Split sentence
            //Create new string[] same size as Splitsentence
            //Iterate each word and find foxWords index
            //Replace humanSpeak index w/ humanword
            string[] foxSpeakSplitted = foxSpeak.Split();
            string[] humanSpeak = new string[foxSpeakSplitted.Length];
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

            //string translatedSentence = "";

            //foreach (string word in humanSpeak)
            //{
            //    translatedSentence += word + " ";
            //}
            
            string translatedSentence = string.Join(" ", humanSpeak);

            return translatedSentence;
        }
    }
}

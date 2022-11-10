using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStore.Utils.Math
{
    public class RandomCustom
    {
        public string RandomWords()
        {
            Random rand = new Random();
            string str = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            string symbol = @"!@#$%^&*,.";

            string text = String.Concat(str, symbol);
            var words = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                words.Add(text[i]);
            }

            //get 8 characters and symbols for new
            string newWords = "";
            for (int i = 0; i < 8; i++)
            {
                newWords += words[rand.Next(text.Length)];
            }
            return newWords;
        }
    }
}
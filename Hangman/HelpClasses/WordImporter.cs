using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman
{
    public class WordImporter 
    {
        public List<string> words { get; set; }
        public string PathToFile { get; set; }

        private static readonly Random random = new Random();

        public WordImporter(string pathToFile)
        {
            this.PathToFile = pathToFile;
        }

        public string GetOneWord()
        {
            if (words == null) throw new ArgumentNullException("Words are yet not imported");

            return words[random.Next(words.Count)];
        }

        public List<string> SetWordsManually(string[] defaultWords)
        {
            words = new List<string>(defaultWords);

            return words;
        }

        public List<string> ImportWordsFromFile()
        {
            if (!File.Exists(PathToFile)) throw new FileNotFoundException("File not found");

            words = new List<string>();

            string line;

            using (var s = new StreamReader(PathToFile))
            {
                while ((line = s.ReadLine()) != null)
                {
                    var arr = line.Split(",");
                    foreach (var word in arr)
                    {
                        words.Add(word.Trim());
                    }
                    
                }
            }

            return words;
        }
    }
}

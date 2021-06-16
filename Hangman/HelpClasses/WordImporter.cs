using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman
{
    public class WordImporter 
    {
        public List<string> Words { get; set; }
        public string PathToFile { get; set; }

        private static readonly Random random = new Random();

        public WordImporter(string pathToFile)
        {
            this.PathToFile = pathToFile;
        }

        public string GetOneWord()
        {
            if (Words == null) throw new ArgumentNullException("Words are yet not imported");

            return Words[random.Next(Words.Count)];
        }

        public List<string> SetWordsManually(string[] defaultWords)
        {
            Words = new List<string>(defaultWords);

            return Words;
        }

        public List<string> ImportWordsFromFile()
        {
            if (!File.Exists(PathToFile)) throw new FileNotFoundException("File not found");

            Words = new List<string>();

            string line;

            using (StreamReader s = new StreamReader(PathToFile))
            {
                while ((line = s.ReadLine()) != null)
                {
                    string[] arr = line.Split(",");
                    foreach (string word in arr)
                    {
                        Words.Add(word.Trim());
                    }
                    
                }
            }

            return Words;
        }
    }
}

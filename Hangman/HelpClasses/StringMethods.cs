using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class StringMethods
    {

        public static char[] GetCharArrayWithChar(int lengthOfArray, char charToAddInArray = '_')
        {
            var charArray = new char[lengthOfArray];

            for (int i = 0; i < lengthOfArray; i++)
            {
                charArray[i] = charToAddInArray;
            }

            return charArray;
        }

        public static bool StringBuilderContainsLetter(StringBuilder stringBuilder, char letter)
        {
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == letter) return true;
            }

            return false;
        }

        public static List<int> IndexesOf(string word, char letter)
        {
            var foundIndexes = new List<int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                    foundIndexes.Add(i);
            }

            return foundIndexes;
        }

        public static void SetLetterInIndexes(List<int> indexes, ref char[] charArray, char letter)
        {
            foreach (var index in indexes)
            {
                charArray[index] = letter;
            }
        }

        public static bool StringMatchesCharArray(string word, char[] charArray)
        {
            return new string(charArray).Equals(word);
        }

        public static void PrintCharArray(char[] charArray)
        {
            foreach (var c in charArray)
            {
                Console.Write(c + "\t");
            }
            Console.WriteLine();
        }
}
}

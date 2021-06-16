using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hangman.test
{
    public class StringMethodsTests
    {
        [Fact]
        public void GetCharArrayWithChar_ShouldMatchLengthAndChar()
        {
            char[] charArray = StringMethods.GetCharArrayWithChar(10, 't');

            Assert.True(charArray.Length == 10);
            foreach (char c in charArray)
            {
                Assert.True(c == 't');
            }
        }

        [Fact]
        public void GetCharArrayWithChar_ShouldMatchDefaultChar()
        {
            char[] charArray = StringMethods.GetCharArrayWithChar(5);

            foreach (char c in charArray)
            {
                Assert.True(c == '_');
            }
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(10, true)]
        [InlineData(1, true)]
        public void GetCharArrayWithChar_ShouldMatchLength(int length, bool expected)
        {
            char[] charArray = StringMethods.GetCharArrayWithChar(length);

            Assert.Equal(charArray.Length == length, expected);
        }

        [Theory]
        [InlineData('s', true)]
        [InlineData('K', true)]
        [InlineData('k', true)]
        [InlineData('ö', false)]
        [InlineData(' ', false)]
        public void StringBuilderContainsLetter_ShouldReturnTrueOrFalse(char letter, bool expected)
        {
            StringBuilder exampleSentence = new StringBuilder("Kokosbollar");

            Assert.Equal(StringMethods.StringBuilderContainsLetter(exampleSentence, letter), expected);
            
        }

        [Fact]
        public void IndexesOf_ShouldReturnListWithThreeIndexes()
        {
            string s = "CHOKLADBULLAR";
            List<int> indexesList = StringMethods.IndexesOf(s, 'L');

            Assert.True(indexesList.Count == 3);
            Assert.True(indexesList[0] == 4);
            Assert.True(indexesList[1] == 9);
            Assert.True(indexesList[2] == 10);

        }

        [Fact]
        public void IndexesOf_ShouldReturnListWithOneIndex()
        {
            string s = "KOKOSMJÖL";
            List<int> indexesList = StringMethods.IndexesOf(s, 'Ö');

            Assert.True(indexesList.Count == 1);
            Assert.True(indexesList[0] == 7);

        }


        [Fact]
        public void IndexesOf_ShouldReturnEmptyList()
        {
            string s = "KOKOSMJÖL";
            List<int> indexesList = StringMethods.IndexesOf(s, 'Y');

            Assert.True(indexesList.Count == 0);
        }


        [Fact]
        public void SetLetterInIndexes_ShouldSetCharacterAtCorrectIndexes()
        {
            char[] charArray = new char[] { 'a', 'b', 'c', 'd', 'e' };
            List<int> indexList = new List<int>() { 0, 3, 4 };
            char c = 't';

            StringMethods.SetLetterInIndexes(indexList, ref charArray, c);

            Assert.True(charArray[indexList[0]] == c);
            Assert.True(charArray[indexList[1]] == c);
            Assert.True(charArray[indexList[2]] == c);
            Assert.True(charArray[2] != c);

        }

         [Fact]
        public void SetLetterInIndexes_ShouldSetCharacterAtCorrectIndex()
        {
            char[] charArray = new char[] { 'a', 'b', 'c', 'd', 'e' };
            List<int> indexList = new List<int>() { 2 };
            char c = 't';

            StringMethods.SetLetterInIndexes(indexList, ref charArray, c);
            Assert.True(charArray[indexList[0]] == c);
            Assert.True(charArray[1] != c);
        }

        [Theory]
        [InlineData("hello", true)]
        [InlineData("he llo", false)]
        [InlineData("goodbye", false)]
        public void StringMatchesCharArray_ShouldReturnTrueOrFalse(string s, bool expected)
        {
            char[] charArray = new char[] { 'h', 'e', 'l', 'l', 'o' };

            Assert.Equal(StringMethods.StringMatchesCharArray(s, charArray), expected);
        }



    }
}

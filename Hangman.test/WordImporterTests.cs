using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Hangman.test
{
    public class WordImporterTests
    {

        [Fact]
        public void WordImporter_TestConstructor()
        {
            string path = "PathToFile";
            WordImporter wordImporter = new WordImporter(path);
            Assert.Equal(wordImporter.PathToFile, path);
        }

        private string FilePath = @"./TestFiles/Words.txt";

        [Fact]
        public void ImportWordsFromFile_ShouldFindFile()
        {
            WordImporter wordImporter = new WordImporter(FilePath);
            List<string> importedWords = wordImporter.ImportWordsFromFile();
            Assert.True(importedWords.Count == 3);
            Assert.Equal("TEST1", importedWords[0]);
            Assert.Equal("TEST2", importedWords[1]);
            Assert.Equal("TEST3", importedWords[2]);

        }

        [Fact]
        public void ImportWordsFromFile_ShouldThrowFileNotFoundException()
        {
            WordImporter wordImporter = new WordImporter("wrongpath");

            Assert.Throws<FileNotFoundException>(() => wordImporter.ImportWordsFromFile());
            Assert.Null(wordImporter.Words);

        }

        [Fact]
        public void GetOneWord_ThrowExceptionWhenWordsAreNotYetImported()
        {
            Assert.Throws<ArgumentNullException>(() => new WordImporter("").GetOneWord());
        }

        [Fact]
        public void GetOneWord_GetARandomWordFromImportedWords()
        {
            WordImporter wordImporter = new WordImporter(FilePath);
            List<string> importedWords = wordImporter.ImportWordsFromFile();
            
            string randomWord = wordImporter.GetOneWord();
            Assert.True(randomWord.Equals("TEST1") || randomWord.Equals("TEST2") || randomWord.Equals("TEST3"));
            randomWord = wordImporter.GetOneWord();
            Assert.True(randomWord.Equals("TEST1") || randomWord.Equals("TEST2") || randomWord.Equals("TEST3"));
            randomWord = wordImporter.GetOneWord();
            Assert.True(randomWord.Equals("TEST1") || randomWord.Equals("TEST2") || randomWord.Equals("TEST3"));

            Assert.True(importedWords.Count == 3);
         
        }

        [Fact]
        public void SetWordsManually_ShouldSetList()
        {
            WordImporter wordImporter = new WordImporter("");
            string[] words = new string[] { "WORD1", "WORD2", "WORD3" };

            wordImporter.SetWordsManually(words);

            Assert.Equal(words.Length, wordImporter.Words.Count);
            Assert.Equal(words[0], wordImporter.Words[0]);
            Assert.Equal(words[1], wordImporter.Words[1]);
            Assert.Equal(words[2], wordImporter.Words[2]);

        }

    }
}

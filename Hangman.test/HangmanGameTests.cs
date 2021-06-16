using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Hangman.test
{

    public class HangmanGameTests
    {

        private HangmanGame hangMan = new HangmanGame(new WordImporter(""));

        [Theory]
        [InlineData("test", true)]
        [InlineData("t", true)]
        [InlineData("T", true)]
        [InlineData("WORD", true)]
        public void CheckForValidInput_ShouldReturnTrue(string word, bool expected)
        {
            Assert.Equal(hangMan.CheckForValidInput(word), expected);

        }

        [Fact]
        public void CheckForValidInput_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => hangMan.CheckForValidInput(null));
            Assert.Throws<ArgumentNullException>(() => hangMan.CheckForValidInput(""));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("word5withnumber")]
        [InlineData("\t")]
        [InlineData("\n")]
        [InlineData("-")]
        [InlineData("word+word-")]
        [InlineData("-l56")]
        public void CheckForValidInput_ShouldThrowInvalidUserInputException(string input)
        {
            Assert.Throws<InvalidUserInputException>(() => hangMan.CheckForValidInput(input));
        }


        [Theory]
        [InlineData("b9")]
        [InlineData("ro-c")]
        [InlineData("df-K")]
        [InlineData("T734")]
        public void GetPlayerInput_ShouldPrintCorrectMessageAfterInvalidInput(string input)
        {
            string expectedString = @"Invalid input, only enter letter/s.";
            StringReader sr = new StringReader(input + "\ngoodWord");

            Console.SetIn(sr);
            StringWriter s = new StringWriter();
            Console.SetOut(s);

            hangMan.GetPlayerInput();

            Assert.Equal(s.ToString().Substring(0, 10), expectedString.Substring(0, 10));
        }

        [Fact]
        public void CheckGuess_WrongGuessShouldIncreaseNrOfGuesses()
        {
            string word = "BANANKAKA";
            int nrOfGuesses = 0;
            char[] correctlyGuessedLetters = StringMethods.GetCharArrayWithChar(word.Length);

            bool wordGuessed = false;

            hangMan.CheckGuess(ref wordGuessed, ref nrOfGuesses, "G", word, ref correctlyGuessedLetters);
            Assert.Equal(1, nrOfGuesses);

            hangMan.CheckGuess(ref wordGuessed, ref nrOfGuesses, "PANNKAKA", word, ref correctlyGuessedLetters);
            Assert.Equal(2, nrOfGuesses);

        }

        [Fact]
        public void CheckGuess_CorrectGuessShouldMakeWordGuessedTrue()
        {
            string word = "BANANKAKA";
            int nrOfGuesses = 0;
            char[] correctlyGuessedLetters = StringMethods.GetCharArrayWithChar(word.Length);
            bool wordGuessed = false;

            hangMan.CheckGuess(ref wordGuessed, ref nrOfGuesses, word, word, ref correctlyGuessedLetters);
            Assert.True(wordGuessed);

        }



    }
 

}

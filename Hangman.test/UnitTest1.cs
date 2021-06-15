using System;
using Xunit;

namespace Hangman.test
{
    public class HangmanGameShould
    {
        [Fact]
        public void test()
        {
            WordImporter wordImporter = new Hangman.WordImporter("");
            HangmanGame c = new HangmanGame(wordImporter);

            c.StartGame();
        }
    }
}

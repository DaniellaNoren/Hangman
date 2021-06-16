
namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame(new WordImporter(@"Words.txt"));
            game.StartGame();
        }
    }

    
   
}

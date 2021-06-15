
namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new HangmanGame(new WordImporter(@"Words.txt"));
            game.StartGame();
        }
    }

    
   
}

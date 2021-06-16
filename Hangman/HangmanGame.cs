using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class HangmanGame
    {
        private readonly WordImporter wordImporter;
        private readonly int numberOfTrys = 10;
        private readonly StringBuilder allGuessedLetters;

        public HangmanGame(WordImporter wordImporter)
        {
            this.wordImporter = wordImporter;
            this.allGuessedLetters = new StringBuilder();
        }

        public void StartGame()
        {
            SetUpWords();
            GameLoop();
        }

        private void SetUpWords()
        {
            try
            {
                wordImporter.ImportWordsFromFile();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, using default words");

                wordImporter.SetWordsManually(new string[] { "ARBETSFÖRMEDLINGEN", "FÖRBUNDSKAPTEN", "RESERVPLATS",
                    "NORDVÄSTERSJÖKUSTARTILLERIFLYGSPANINGSSIMULATORANLÄGGNINGSMATERIELUNDERHÅLLSUPPFÖLJNINGSSYSTEMDISKUSSIONSINLÄGGSFÖRBEREDELSEARBETE",
                    "STACKOVERFLOW", "HANGMAN", "VÄGGISOLERING", "GUMMIDÄCK", "STORMVIND", "DADDLAR" });
            }

        }

        private void GameLoop()
        {
            string input;

            Console.WriteLine("Welcome to Hangman! Enter a letter or word to guess!");

            do
            {
                allGuessedLetters.Clear();

                string word = wordImporter.GetOneWord();
                bool wonGame = GuessWord(word);

                if (wonGame)
                {
                    Console.WriteLine("You did it! You guessed " + word.ToUpper());
                }
                else
                {
                    Console.WriteLine("You failed!");
                }

                Console.WriteLine("Do you want to play again? Press enter to continue, type -1 to exit");
                input = Console.ReadLine();

            } while (input != "-1");
        }



        private bool GuessWord(string wordToBeGuessed)
        {
            wordToBeGuessed = wordToBeGuessed.ToUpper();
           
            int nrOfGuesses = 0;
            char[] correctlyGuessedLetters = StringMethods.GetCharArrayWithChar(wordToBeGuessed.Length);    
            bool WordHasBeenGuessed = false;

            while (nrOfGuesses < numberOfTrys && !WordHasBeenGuessed)
            {
                StringMethods.PrintCharArray(correctlyGuessedLetters);                                                
                
                Console.WriteLine("\n" + allGuessedLetters);                                               

                string guess = GetPlayerInput();

                CheckGuess(ref WordHasBeenGuessed, ref nrOfGuesses, guess, wordToBeGuessed, ref correctlyGuessedLetters);
         
            }

            return nrOfGuesses < numberOfTrys;
        }

        public void CheckGuess(ref bool wordHasBeenGuessed, ref int nrOfGuesses, string guess, string wordToBeGuessed, ref char[] correctlyGuessedLetters)
        {
            
            if (guess.Length == 1)
            {
                char guessedLetter = guess[0];

                if (StringMethods.StringBuilderContainsLetter(allGuessedLetters, guessedLetter))
                {
                    Console.WriteLine("Letter already guessed, try again");
                    return;
                }
                else
                {
                    allGuessedLetters.Append(guessedLetter);
                }

                if (GuessedLetterIsCorrect(ref correctlyGuessedLetters, guessedLetter, wordToBeGuessed))
                {
                    wordHasBeenGuessed = StringMethods.StringMatchesCharArray(wordToBeGuessed, correctlyGuessedLetters);
                }
                else
                {
                    nrOfGuesses++;
                }

            }
            else if (guess.Equals(wordToBeGuessed))                                                     
            {
                wordHasBeenGuessed = true;
            }
            else
            {
                nrOfGuesses++;                                                                              
            }

            
        }
    
        public bool GuessedLetterIsCorrect(ref char[] charArray, char guess, string wordToBeGuessed)
        {
            List<int> indexes = StringMethods.IndexesOf(wordToBeGuessed, guess);                   

            if (indexes.Count > 0)                                                                         
            {
                StringMethods.SetLetterInIndexes(indexes, ref charArray, guess);                   

                return true;
            }
           return false;
        }

        public string GetPlayerInput()
        {
            bool correctInput = false;
            string playerInput = "";

            do
            {
                try
                {
                    playerInput = Console.ReadLine().ToUpper().Trim();
                    correctInput = CheckForValidInput(playerInput);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Input cannot be empty.");
                }
                catch (InvalidUserInputException)
                {
                    Console.WriteLine("Invalid input, only enter letter/s");   
                }
            } while (!correctInput);

            return playerInput;
        }

        public bool CheckForValidInput(string word)
        {
            if (null == word || word.Equals(""))
                throw new ArgumentNullException();
            if (Regex.IsMatch(word, @"[\s+\d+\W+\b+]"))  // Check if word has any numbers, special characters or blank spaces in it
                throw new InvalidUserInputException();

            return true;

        }

    } 
}

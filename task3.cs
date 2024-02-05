using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Shiritori
    {
        public List<string> words;
        public bool game_over;

        public Shiritori()// constructor of the class
        {
            words = new List<string>();
            game_over = false;
        }

        public object Play(string word)
        {
            if (game_over)
            {
                return "BOOOOOMMMM!!! GAME OVER :(";
            }
            if (words.Count == 0)
            {
                words.Add(word);
                return words;
            }

            int lastIndex = words.Count - 1; // calculate the last index of the word
            string lastWord = words[lastIndex];

            if (string.Equals(lastWord, word, StringComparison.OrdinalIgnoreCase))
            {
                words.Add(word);
                return words;
            }

            if (char.ToLower(lastWord[lastWord.Length - 1]) == char.ToLower(word[0]))
            {
                // (StringComparer.OrdinalIgnoreCase) ignores the case of the leters entered by the user
                if (!words.Contains(word, StringComparer.OrdinalIgnoreCase))  // Check if the word already exists
                {
                    words.Add(word);
                    return words;
                }
                else
                {
                    Console.WriteLine("The word already exists. Please enter a new word.");
                    return words;
                }
            }
            game_over = true;
            return "BOOOOOMMMM!!! GAME OVER :(";

        }


            public string Restart()
        {
            words.Clear();
            Console.Clear();
            game_over = false;
            return "WOHHHHOOO!!! GAME STARTED AGAINN:)";
        }
    }

    class Program
    {
        static void Main()
        {
            Shiritori myShiritori = new Shiritori();
            Console.WriteLine("WELCOME TO SHIRITORI GAME:)");
            while (true)
            {
                Console.WriteLine("Enter a word (or type 'quit' to exit): ");
                string input = Console.ReadLine().ToLower();// convert to lowercase 

                if (input == "quit")
                {
                    Console.ReadKey();
                    break;
                }

                object result = myShiritori.Play(input);

                if (result is List<string>)
                {
                    Console.WriteLine($"Current words: {string.Join(", ", myShiritori.words)}");
                }
                else
                {
                    Console.WriteLine(result);
                    Console.WriteLine($"Final words: {string.Join(", ", myShiritori.words)}");
                    Console.WriteLine("Do you want to restart the game(N for No and Y for Yes): ");
                    char option = char.Parse(Console.ReadLine());
                    if(option=='Y')
                    {
                        Console.WriteLine(myShiritori.Restart());
                    }
                    else
                    {
                        Console.WriteLine("Exiting the program.GoodBye!");
                        Console.ReadKey();
                        break;
                    }
                    
                }
            }
        }
    }

}

using System;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.XPath;

namespace FunctionChallenges
{
    class Program
    {
        static void Main(string[] args)

        {

            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            Console.WriteLine(StringNumberProcessor("Hello", 100, 200, "World")); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            // Console.WriteLine("\nChallenge 2: Object Swapper");
            // int num1 = 25, num2 = 30;
            // int num 3 = 10, num4 = 30;
            // string str1 = "HelloWorld", str2 = "Programming";
            // string str3 = "Hi", str4 = "Programming";

            // SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            // SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            // SwapObjects(str1, str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            // SwapObjects(str3, str4); // Error: Length must be more than 5

            // SwapObjects(true, false); // Error: Upsupported data type
            // SwapObjects(ref num1, str1); // Error: Objects must be of same types

            // Console.WriteLine($"Numbers: {num1}, {num2}");
            // Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            // Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            // string sentence = "This is the original sentence!";
            // string reversed = ReverseWords(sentence);
            // Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
        public static StringBuilder StringNumberProcessor(params object[] obj)
        {
            StringBuilder str = new StringBuilder("");
            int sum = 0;
            foreach (object x in obj)
            {
                switch (x)
                {
                    case int: sum += (int)x; break;
                    case string: str.Append($"{x} "); break;
                };
            }
            // This if statement to just make the format as expected "Hello World; 300" not "Hello World ; 300"
            if (str.Length > 0)
            {
                str.Remove(str.Length - 1, 1);
            }
            return str.Append($"; {sum}");

        }
        public static void GuessingGame()
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            Console.WriteLine(number);

            while (true)
            {
                Console.Write("Guess the number between 1 and 100, or type 'quit' to exit: ");
                string input = Console.ReadLine() ?? "";
                input.ToLower();
                if (input == "quit")
                {
                    Console.WriteLine("End the game. The number was: " + number);

                    break;
                }
                if (!int.TryParse(input, out int guessNumber) || guessNumber < 1 || guessNumber > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100");
                    continue;
                }
                if (guessNumber < number)
                {
                    Console.WriteLine("Too low. Try again...");
                }
                else if (guessNumber > number)
                {
                    Console.WriteLine("Too high. Try again...");
                }
                else
                {
                    Console.WriteLine("CONGRATULATIONS! YOU'VE GUESSED THE NUMBER " + number);
                    break;
                }

            }
        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace FunctionChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main loop for executing challenges
            while (true)
            {
                try
                {
                    // Display menu options
                    Console.WriteLine("Welcome to the challenging App");
                    Console.WriteLine("\t1- String and Number Processor");
                    Console.WriteLine("\t2- Object Swapper");
                    Console.WriteLine("\t3- Guessing Game");
                    Console.WriteLine("\t4- Simple Word Reversal");
                    Console.Write("Choose one of the challenges or type 'exit' to quit: ");
                    string input = Console.ReadLine()?.ToLower() ?? "";

                    // Exiting the program if the user inputs 'exit'
                    if (input == "exit")
                    {
                        Console.WriteLine("Thank you for using our app");
                        Environment.Exit(0);
                    }

                    // Validating user input
                    if (!int.TryParse(input, out int challengeNumber))
                    {
                        throw new ArgumentException("Invalid input, try again");
                    }
                    if (challengeNumber < 1 || challengeNumber > 4)
                    {
                        throw new ArgumentException("Please enter a valid challenge number between 1 and 4");
                    }

                    // Executing the selected challenge
                    switch (challengeNumber)
                    {
                        case 1:
                            ExecuteStringNumberProcessor();
                            break;
                        case 2:
                            ExecuteObjectSwapper();
                            break;
                        case 3:
                            GuessingGame();
                            break;
                        case 4:
                            ExecuteWordReversal();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    // Handling argument exceptions
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Handling other exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        // Executes the String and Number Processor challenge
        static void ExecuteStringNumberProcessor()
        {
            // Display challenge description
            Console.WriteLine("Challenge 1: String and Number Processor");
            Console.Write("Enter any number of strings and integers separated by space: ");
            string inputs = Console.ReadLine() ?? "";

            // Handling empty input
            if (string.IsNullOrWhiteSpace(inputs))
            {
                throw new ArgumentException("Input cannot be empty");
            }

            // Splitting input parameters
            string[] inputParams = inputs.Trim().Split(' ');
            object[] parameters = new object[inputParams.Length];

            // Parsing input strings to objects
            for (int i = 0; i < inputParams.Length; i++)
            {
                if (int.TryParse(inputParams[i], out int intValue))
                    parameters[i] = intValue;
                else
                    parameters[i] = inputParams[i];
            }

            // Processing the input and displaying the result
            Console.WriteLine(StringNumberProcessor(parameters));
        }

        // Executes the Object Swapper challenge
        static void ExecuteObjectSwapper()
        {
            // Display challenge description
            Console.WriteLine("Challenge 2: Object Swapper");
            Console.Write("Please enter two inputs (both should be string or integer and have the same data type): ");
            string inputs = Console.ReadLine()?.Trim() ?? "";

            // Handling empty input
            if (string.IsNullOrWhiteSpace(inputs))
            {
                throw new ArgumentException("Input cannot be empty");
            }

            // Splitting input parameters
            string[] inputParams = inputs.Split(' ');

            // Checking if exactly two inputs are provided
            if (inputParams.Length != 2)
            {
                throw new ArgumentException("Please enter exactly two inputs separated by a space");
            }

            // Parsing input strings to objects
            object[] parameters = new object[inputParams.Length];
            for (int i = 0; i < inputParams.Length; i++)
            {
                if (int.TryParse(inputParams[i], out int intValue))
                {
                    parameters[i] = intValue;
                }
                else if (double.TryParse(inputParams[i], out double doubleValue))
                {
                    throw new ArgumentException("Unsupported data type");
                }
                else if (bool.TryParse(inputParams[i], out bool _))
                {
                    throw new ArgumentException("Unsupported data type");
                }
                else
                {
                    parameters[i] = inputParams[i]; // Otherwise, store it as string
                }
            }

            // Extracting objects from parameters
            object obj1 = parameters[0];
            object obj2 = parameters[1];

            // Checking if objects are of the same type
            if (obj1.GetType() != obj2.GetType())
            {
                throw new ArgumentException("Objects must be of the same type");
            }

            // Swapping objects and displaying the result
            if (obj1 is int)
            {
                int value1 = (int)obj1;
                int value2 = (int)obj2;
                SwapObjects(ref value1, ref value2);
                Console.WriteLine($"Integers: {value1}, {value2}");
            }
            else if (obj1 is string)
            {
                string str1 = (string)obj1;
                string str2 = (string)obj2;
                SwapObjects(ref str1, ref str2); // Swapping strings
                Console.WriteLine($"Strings: {str1}, {str2}");
            }
            else
            {
                throw new ArgumentException("Unsupported data type");
            }
        }

        // Executes the Guessing Game challenge
        static void GuessingGame()
        {
            // Generating a random number
            Random random = new Random();
            int number = random.Next(1, 100);

            while (true)
            {
                // Prompting user to guess the number
                Console.Write("Guess the number between 1 and 100, or type 'quit' to exit: ");
                string input = Console.ReadLine()?.ToLower() ?? "";

                // Ending the game if user quits
                if (input == "quit")
                {
                    Console.WriteLine("Ending the game. The number was: " + number);
                    break;
                }

                // Validating user input
                if (!int.TryParse(input, out int guessNumber))
                {
                    throw new ArgumentException("Invalid input. Please enter only number");
                }
                if (guessNumber < 1 || guessNumber > 100)
                {
                    throw new ArgumentException("Invalid input. Please enter a number between 1 and 100");

                }

                // Providing feedback on the user's guess
                if (guessNumber < number)
                    Console.WriteLine("Too low. Try again");
                else if (guessNumber > number)
                    Console.WriteLine("Too high. Try again");
                else
                {
                    Console.WriteLine("CONGRATULATIONS! YOU'VE GUESSED THE NUMBER " + number);
                    break;
                }
            }
        }

        // Executes the Simple Word Reversal challenge
        static void ExecuteWordReversal()
        {
            // Display challenge description
            Console.WriteLine("Challenge 4: Simple Word Reversal");
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine()?.Trim() ?? "";

            // Handling empty input
            if (string.IsNullOrWhiteSpace(sentence))
            {
                throw new ArgumentException("Input cannot be empty");
            }

            // Reversing words in the sentence and displaying the result
            string reversed = ReverseWords(sentence);
            Console.WriteLine("Reversed sentence: " + reversed);
        }

        // Method to process strings and numbers
        static StringBuilder StringNumberProcessor(params object[] obj)
        {
            // Checking if at least one parameter is provided
            if (obj == null || obj.Length == 0)
                throw new ArgumentException("At least one parameter is required");

            // Initializing StringBuilder for result
            StringBuilder str = new StringBuilder();
            int sum = 0;

            // Iterating through each object in parameters
            foreach (object x in obj)
            {
                switch (x)
                {
                    case int intValue:
                        // If the object is an integer, add it to the sum
                        sum += intValue;
                        break;
                    case string stringValue when !string.IsNullOrWhiteSpace(stringValue):
                        // If the object is a non-empty string, append it to StringBuilder
                        str.Append($"{stringValue.Trim()} ");
                        break;
                    default:
                        // If the object is of unsupported type, throw exception
                        throw new ArgumentException("Unsupported parameter type");
                }
            }

            // Checking if any strings were appended
            if (str.Length == 0)
                // If no strings were appended, append the sum only
                str.Append($"{sum}");
            else
                // If strings were appended remove the last space and append the sum
                str.Remove(str.Length - 1, 1).Append($"; {sum}");

            // Returning the result
            return str;
        }

        // Method to reverse words in a sentence
        static string ReverseWords(string originalSentence)
        {
            // Handling empty input
            if (string.IsNullOrWhiteSpace(originalSentence))
            {
                throw new ArgumentException("Invalid input string");
            }

            // Splitting sentence into words
            string[] sentenceArray = originalSentence.Trim().Split(" ");
            string reversedSentence = "";

            // Reversing each word and appending to result
            foreach (string str in sentenceArray)
            {
                reversedSentence = reversedSentence + new string(str.Reverse().ToArray()) + " ";
            }

            // Returning the reversed sentence
            return reversedSentence;
        }

        // Method to swap two integers
        static void SwapObjects(ref int num1, ref int num2)
        {
            // Checking if values are greater than 18
            if (num1 <= 18 || num2 <= 18)
            {
                throw new ArgumentException("Values must be more than 18");
            }

            // Swapping the values
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        // Method to swap two strings
        public static void SwapObjects(ref string str1, ref string str2)
        {
            // Checking if lengths of strings are greater than 5
            if (str1.Length <= 5 || str2.Length <= 5)
            {
                throw new ArgumentException("Length must be more than 5");
            }

            // Swapping the strings
            string temp = str1;
            str1 = str2;
            str2 = temp;
        }
    }
}

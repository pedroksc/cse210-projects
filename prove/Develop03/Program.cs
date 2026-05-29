using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Moroni", 10, 4, 5);

            string scriptureText =
                "And when ye shall receive these things I would exhort you that ye would ask God " +
                "the Eternal Father in the name of Christ if these things are not true and if ye " +
                "shall ask with a sincere heart with real intent having faith in Christ he will " +
                "manifest the truth of it unto you by the power of the Holy Ghost And by the power " +
                "of the Holy Ghost ye may know the truth of all things";

            Scripture scripture = new Scripture(reference, scriptureText);

            int wordsToHide = ChooseDifficulty();

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("All words are hidden. Great work memorizing the scripture!");
                    break;
                }

                Console.Write("Press Enter to continue or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input != null && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye! Keep memorizing!");
                    break;
                }

                scripture.HideRandomWords(wordsToHide);
            }
        }

        static int ChooseDifficulty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Scripture Memorizer ===");
                Console.WriteLine("Choose a difficulty level:");
                Console.WriteLine("  1 - Easy   (hide 2 words at a time)");
                Console.WriteLine("  2 - Medium (hide 4 words at a time)");
                Console.WriteLine("  3 - Hard   (hide 6 words at a time)");
                Console.Write("Enter 1, 2, or 3: ");

                string input = Console.ReadLine();

                if (input == "1") return 2;
                if (input == "2") return 4;
                if (input == "3") return 6;

                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                Console.ReadLine();
            }
        }
    }
}

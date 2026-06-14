using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing Activity", 0 },
            { "Reflection Activity", 0 },
            { "Listing Activity", 0 }
        };

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");

            // Display session activity log
            Console.WriteLine("--- Session Activity Log ---");
            foreach (var entry in activityLog)
            {
                Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
            }
            Console.WriteLine();

            // Display the menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityLog["Breathing Activity"]++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    activityLog["Reflection Activity"]++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityLog["Listing Activity"]++;
                    break;

                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
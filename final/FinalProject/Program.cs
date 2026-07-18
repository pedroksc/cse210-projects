using System;

namespace DoorToDoorSalesTracker
{
    // Program is the entry point of the application. Its only job is to get
    // the CommissionSettings ready (loading them if saved, or asking for them
    // the first time), then hand control over to the Menu.
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Door-to-Door Internet Sales Tracker!");
            Console.WriteLine();

            CommissionSettings settings = GetOrCreateCommissionSettings();
            SalesTracker tracker = new SalesTracker(settings);
            Menu menu = new Menu(tracker);
            menu.Run();
        }

        private static CommissionSettings GetOrCreateCommissionSettings()
        {
            if (FileManager.CommissionSettingsExist())
            {
                return FileManager.LoadCommissionSettings();
            }

            Console.WriteLine("It looks like this is your first time running the program.");
            decimal baseCommission = ReadPositiveDecimal("Enter your base commission per full deal: ");

            CommissionSettings settings = new CommissionSettings(baseCommission);
            FileManager.SaveCommissionSettings(settings);

            Console.WriteLine($"Got it! Your base commission is set to {baseCommission:C}.");
            Console.WriteLine();

            return settings;
        }

        private static decimal ReadPositiveDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (decimal.TryParse(input, out decimal result) && result > 0)
                {
                    return result;
                }

                Console.WriteLine("Please enter a positive number (example: 250).");
            }
        }
    }
}

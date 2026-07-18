using System;

namespace DoorToDoorSalesTracker
{
    // Menu is responsible for all direct console interaction with the user:
    // showing options, reading input, validating it, and calling the correct
    // method on SalesTracker. This keeps input/output logic separate from
    // the business logic in SalesTracker, ReportGenerator, etc.
    public class Menu
    {
        private SalesTracker tracker;
        private bool running;

        public Menu(SalesTracker tracker)
        {
            this.tracker = tracker;
            this.running = true;
        }

        public void Run()
        {
            while (running)
            {
                ShowOptions();
                string choice = Console.ReadLine() ?? string.Empty;
                Console.WriteLine();

                switch (choice.Trim())
                {
                    case "1":
                        AddDailyReport();
                        break;
                    case "2":
                        tracker.DisplayAllReports();
                        break;
                    case "3":
                        tracker.DisplayTotalCommissionReport();
                        break;
                    case "4":
                        tracker.DisplayReflections();
                        break;
                    case "5":
                        ChangeCommissionSetup();
                        break;
                    case "6":
                        SaveAndQuit();
                        break;
                    default:
                        Console.WriteLine("That is not a valid option. Please enter a number 1-6.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ShowOptions()
        {
            Console.WriteLine("========== DOOR-TO-DOOR INTERNET SALES TRACKER ==========");
            Console.WriteLine("1. Add daily report");
            Console.WriteLine("2. View all daily reports");
            Console.WriteLine("3. View total commission report");
            Console.WriteLine("4. View reflections");
            Console.WriteLine("5. Change commission setup");
            Console.WriteLine("6. Save and quit");
            Console.Write("Enter your choice: ");
        }

        private void AddDailyReport()
        {
            Console.WriteLine("----- Add Daily Report -----");

            DateTime date = ReadDate("Enter the date (yyyy-MM-dd), or press Enter for today: ");
            int doorsKnocked = ReadNonNegativeInt("Doors knocked: ");
            int peopleTalkedTo = ReadNonNegativeInt("People talked to: ");
            int presentationsGiven = ReadNonNegativeInt("Presentations given: ");
            int count1000 = ReadNonNegativeInt("Number of 1000 Mbps sales: ");
            int count500 = ReadNonNegativeInt("Number of 500 Mbps sales: ");
            int count250 = ReadNonNegativeInt("Number of 250 Mbps sales: ");

            Console.Write("What went well today? ");
            string wentWell = Console.ReadLine() ?? string.Empty;

            Console.Write("What went badly today? ");
            string wentBadly = Console.ReadLine() ?? string.Empty;

            Console.Write("What is one goal for tomorrow? ");
            string goal = Console.ReadLine() ?? string.Empty;

            DailyReflection reflection = new DailyReflection(wentWell, wentBadly, goal);
            DailySalesReport report = new DailySalesReport(date, doorsKnocked, peopleTalkedTo,
                presentationsGiven, count1000, count500, count250, reflection);

            tracker.AddReport(report);

            Console.WriteLine();
            Console.WriteLine("Report saved! Here is today's summary:");
            Console.WriteLine(new ReportGenerator(tracker.Settings).GenerateDailySummary(report));
        }

        private void ChangeCommissionSetup()
        {
            Console.WriteLine("----- Change Commission Setup -----");
            Console.WriteLine($"Current base commission: {tracker.Settings.GetBaseCommission():C}");
            decimal newAmount = ReadPositiveDecimal("Enter new base commission per full deal: ");
            tracker.UpdateBaseCommission(newAmount);
            Console.WriteLine($"Base commission updated to {newAmount:C}.");
        }

        private void SaveAndQuit()
        {
            tracker.SaveReports();
            FileManager.SaveCommissionSettings(tracker.Settings);
            Console.WriteLine("All data saved. Goodbye!");
            running = false;
        }

        // ----- Input helper methods with validation -----

        private DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    return DateTime.Today;
                }

                if (DateTime.TryParse(input, out DateTime result))
                {
                    return result;
                }

                Console.WriteLine("That date was not recognized. Please try again (example: 2026-06-30).");
            }
        }

        private int ReadNonNegativeInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int result) && result >= 0)
                {
                    return result;
                }

                Console.WriteLine("Please enter a whole number that is zero or greater.");
            }
        }

        private decimal ReadPositiveDecimal(string prompt)
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

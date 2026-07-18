using System;

namespace DoorToDoorSalesTracker
{
    // DailyReflection stores the salesperson's end-of-day notes.
    // It is used inside DailySalesReport (composition).
    // Demonstrates encapsulation: fields are private, accessed only through properties.
    public class DailyReflection
    {
        private string wentWell;
        private string wentBadly;
        private string goalForTomorrow;

        public DailyReflection(string wentWell, string wentBadly, string goalForTomorrow)
        {
            this.wentWell = wentWell ?? string.Empty;
            this.wentBadly = wentBadly ?? string.Empty;
            this.goalForTomorrow = goalForTomorrow ?? string.Empty;
        }

        public string WentWell
        {
            get => wentWell;
            set => wentWell = value ?? string.Empty;
        }

        public string WentBadly
        {
            get => wentBadly;
            set => wentBadly = value ?? string.Empty;
        }

        public string GoalForTomorrow
        {
            get => goalForTomorrow;
            set => goalForTomorrow = value ?? string.Empty;
        }

        // Produces a readable block of text for display or file storage.
        public string GetSummary()
        {
            return $"What went well: {wentWell}\n" +
                   $"What went badly: {wentBadly}\n" +
                   $"Goal for tomorrow: {goalForTomorrow}";
        }

        // Converts fields into a single pipe-delimited line for CSV-style saving.
        // Newlines inside the text are replaced so each reflection stays on one line.
        public string ToFileString()
        {
            return $"{Sanitize(wentWell)}|{Sanitize(wentBadly)}|{Sanitize(goalForTomorrow)}";
        }

        private string Sanitize(string text)
        {
            return text.Replace("|", "/").Replace("\n", " ").Replace("\r", " ");
        }

        // Rebuilds a DailyReflection from a saved pipe-delimited string.
        public static DailyReflection FromFileString(string data)
        {
            string[] parts = data.Split('|');
            string well = parts.Length > 0 ? parts[0] : string.Empty;
            string badly = parts.Length > 1 ? parts[1] : string.Empty;
            string goal = parts.Length > 2 ? parts[2] : string.Empty;
            return new DailyReflection(well, badly, goal);
        }
    }
}

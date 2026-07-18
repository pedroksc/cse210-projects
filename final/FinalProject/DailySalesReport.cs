using System;

namespace DoorToDoorSalesTracker
{
    // DailySalesReport represents everything that happened on one day of door-to-door
    // selling. Demonstrates encapsulation: all fields are private, with public
    // properties/methods controlling access and validation.
    public class DailySalesReport
    {
        private DateTime date;
        private int doorsKnocked;
        private int peopleTalkedTo;
        private int presentationsGiven;
        private int count1000Mbps;
        private int count500Mbps;
        private int count250Mbps;
        private DailyReflection reflection;

        public DailySalesReport(DateTime date, int doorsKnocked, int peopleTalkedTo,
            int presentationsGiven, int count1000Mbps, int count500Mbps, int count250Mbps,
            DailyReflection reflection)
        {
            this.date = date;
            this.doorsKnocked = Math.Max(0, doorsKnocked);
            this.peopleTalkedTo = Math.Max(0, peopleTalkedTo);
            this.presentationsGiven = Math.Max(0, presentationsGiven);
            this.count1000Mbps = Math.Max(0, count1000Mbps);
            this.count500Mbps = Math.Max(0, count500Mbps);
            this.count250Mbps = Math.Max(0, count250Mbps);
            this.reflection = reflection;
        }

        public DateTime Date => date;
        public int DoorsKnocked => doorsKnocked;
        public int PeopleTalkedTo => peopleTalkedTo;
        public int PresentationsGiven => presentationsGiven;
        public int Count1000Mbps => count1000Mbps;
        public int Count500Mbps => count500Mbps;
        public int Count250Mbps => count250Mbps;
        public DailyReflection Reflection => reflection;

        // Total number of internet plans sold that day, regardless of type.
        public int GetTotalSales()
        {
            return count1000Mbps + count500Mbps + count250Mbps;
        }

        // Close rate = total sales / presentations given.
        // Returns 0 if no presentations were given, to avoid dividing by zero.
        public decimal GetCloseRate()
        {
            if (presentationsGiven == 0)
            {
                return 0m;
            }

            return (decimal)GetTotalSales() / presentationsGiven;
        }

        // Contact rate = people talked to / doors knocked.
        // Returns 0 if no doors were knocked, to avoid dividing by zero.
        public decimal GetContactRate()
        {
            if (doorsKnocked == 0)
            {
                return 0m;
            }

            return (decimal)peopleTalkedTo / doorsKnocked;
        }

        // Serializes the report (without the reflection) into a single CSV line.
        // The reflection is appended separately by FileManager since it may contain
        // its own delimiter-safe text.
        public string ToFileString()
        {
            return $"{date:yyyy-MM-dd},{doorsKnocked},{peopleTalkedTo},{presentationsGiven}," +
                   $"{count1000Mbps},{count500Mbps},{count250Mbps}";
        }

        public static DailySalesReport FromFileParts(string[] parts, DailyReflection reflection)
        {
            DateTime parsedDate = DateTime.TryParse(parts[0], out DateTime d) ? d : DateTime.Today;
            int doors = int.TryParse(parts[1], out int dk) ? dk : 0;
            int talked = int.TryParse(parts[2], out int pt) ? pt : 0;
            int presentations = int.TryParse(parts[3], out int pg) ? pg : 0;
            int c1000 = int.TryParse(parts[4], out int c1) ? c1 : 0;
            int c500 = int.TryParse(parts[5], out int c2) ? c2 : 0;
            int c250 = int.TryParse(parts[6], out int c3) ? c3 : 0;

            return new DailySalesReport(parsedDate, doors, talked, presentations,
                c1000, c500, c250, reflection);
        }
    }
}

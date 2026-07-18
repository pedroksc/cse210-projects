using System;
using System.Collections.Generic;
using System.IO;

namespace DoorToDoorSalesTracker
{
    // FileManager handles all reading and writing to disk.
    // Keeping file I/O in one place means no other class needs to know exactly
    // where or how data is stored -- they just ask FileManager to save or load.
    public static class FileManager
    {
        private const string CommissionFile = "commission.txt";
        private const string ReportsFile = "reports.csv";

        public static bool CommissionSettingsExist()
        {
            return File.Exists(CommissionFile);
        }

        public static void SaveCommissionSettings(CommissionSettings settings)
        {
            File.WriteAllText(CommissionFile, settings.ToFileString());
        }

        public static CommissionSettings LoadCommissionSettings()
        {
            string data = File.ReadAllText(CommissionFile);
            return CommissionSettings.FromFileString(data.Trim());
        }

        // Saves every daily report as one line of CSV, followed by a pipe-delimited
        // reflection block appended to the end of the same line.
        public static void SaveReports(List<DailySalesReport> reports)
        {
            List<string> lines = new List<string>();

            foreach (DailySalesReport report in reports)
            {
                string reportPart = report.ToFileString();
                string reflectionPart = report.Reflection.ToFileString();
                lines.Add($"{reportPart},{reflectionPart}");
            }

            File.WriteAllLines(ReportsFile, lines);
        }

        public static List<DailySalesReport> LoadReports()
        {
            List<DailySalesReport> reports = new List<DailySalesReport>();

            if (!File.Exists(ReportsFile))
            {
                return reports;
            }

            string[] lines = File.ReadAllLines(ReportsFile);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // The first 7 comma-separated values are the report fields.
                // Everything after that (still comma-separated, then pipe-separated
                // inside) belongs to the reflection.
                string[] allParts = line.Split(',');
                if (allParts.Length < 8)
                {
                    continue;
                }

                string[] reportParts = new string[7];
                Array.Copy(allParts, reportParts, 7);

                // Rejoin the remaining pieces in case the reflection text itself
                // contained a comma that survived sanitization.
                string reflectionData = string.Join(",", allParts, 7, allParts.Length - 7);
                DailyReflection reflection = DailyReflection.FromFileString(reflectionData);

                DailySalesReport report = DailySalesReport.FromFileParts(reportParts, reflection);
                reports.Add(report);
            }

            return reports;
        }
    }
}

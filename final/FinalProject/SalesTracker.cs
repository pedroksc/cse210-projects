using System;
using System.Collections.Generic;

namespace DoorToDoorSalesTracker
{
    // SalesTracker is the central manager of the application's data.
    // It owns the list of daily reports and delegates commission math to
    // ReportGenerator, and delegates persistence to FileManager.
    public class SalesTracker
    {
        private List<DailySalesReport> reports;
        private CommissionSettings settings;
        private ReportGenerator generator;

        public SalesTracker(CommissionSettings settings)
        {
            this.settings = settings;
            this.generator = new ReportGenerator(settings);
            this.reports = FileManager.LoadReports();
        }

        public CommissionSettings Settings => settings;

        public void AddReport(DailySalesReport report)
        {
            reports.Add(report);
            SaveReports();
        }

        public List<DailySalesReport> GetAllReports()
        {
            return reports;
        }

        public void DisplayAllReports()
        {
            if (reports.Count == 0)
            {
                Console.WriteLine("No daily reports have been added yet.");
                return;
            }

            for (int i = 0; i < reports.Count; i++)
            {
                Console.WriteLine($"----- Report {i + 1} -----");
                Console.WriteLine(generator.GenerateDailySummary(reports[i]));
            }
        }

        public void DisplayTotalCommissionReport()
        {
            Console.WriteLine("===== TOTAL COMMISSION REPORT =====");
            Console.WriteLine(generator.GenerateTotalCommissionReport(reports));
        }

        public void DisplayReflections()
        {
            if (reports.Count == 0)
            {
                Console.WriteLine("No reflections have been recorded yet.");
                return;
            }

            for (int i = 0; i < reports.Count; i++)
            {
                Console.WriteLine($"----- Reflection for {reports[i].Date:yyyy-MM-dd} -----");
                Console.WriteLine(reports[i].Reflection.GetSummary());
                Console.WriteLine();
            }
        }

        public void UpdateBaseCommission(decimal newAmount)
        {
            settings.SetBaseCommission(newAmount);
            FileManager.SaveCommissionSettings(settings);
        }

        public void SaveReports()
        {
            FileManager.SaveReports(reports);
        }
    }
}

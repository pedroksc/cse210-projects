using System;
using System.Collections.Generic;
using System.Text;

namespace DoorToDoorSalesTracker
{
    // ReportGenerator turns raw DailySalesReport data into readable summaries and
    // dollar totals. It demonstrates POLYMORPHISM: it works with a list of
    // InternetPlan references and calls CalculateCommission() on each one without
    // ever needing to know (or check) which specific plan type it is holding.
    public class ReportGenerator
    {
        private CommissionSettings settings;

        public ReportGenerator(CommissionSettings settings)
        {
            this.settings = settings;
        }

        // Builds the three InternetPlan objects for the current base commission.
        // Stored as a list of the abstract type InternetPlan -- this is the
        // polymorphic collection the rest of the class works with.
        private List<InternetPlan> BuildPlans()
        {
            decimal baseAmount = settings.GetBaseCommission();
            return new List<InternetPlan>
            {
                new ThousandMbpsPlan(baseAmount),
                new FiveHundredMbpsPlan(baseAmount),
                new TwoHundredFiftyMbpsPlan(baseAmount)
            };
        }

        // Returns commission earned for each plan type as a dictionary keyed by plan name,
        // plus the grand total, for one daily report.
        public (decimal thousandTotal, decimal fiveHundredTotal, decimal twoFiftyTotal, decimal grandTotal)
            CalculateDailyCommission(DailySalesReport report)
        {
            List<InternetPlan> plans = BuildPlans();
            int[] quantities = { report.Count1000Mbps, report.Count500Mbps, report.Count250Mbps };

            decimal[] totals = new decimal[3];
            decimal grandTotal = 0m;

            // Polymorphism in action: the same CalculateCommission() call works
            // correctly for every plan type in the list, even though each type
            // calculates its rate differently under the hood.
            for (int i = 0; i < plans.Count; i++)
            {
                InternetPlan plan = plans[i];
                decimal planTotal = plan.CalculateCommission(quantities[i]);
                totals[i] = planTotal;
                grandTotal += planTotal;
            }

            return (totals[0], totals[1], totals[2], grandTotal);
        }

        // Produces a human-readable summary block for a single day.
        public string GenerateDailySummary(DailySalesReport report)
        {
            var (thousand, fiveHundred, twoFifty, grandTotal) = CalculateDailyCommission(report);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Date: {report.Date:yyyy-MM-dd}");
            sb.AppendLine($"Doors knocked: {report.DoorsKnocked}");
            sb.AppendLine($"People talked to: {report.PeopleTalkedTo}");
            sb.AppendLine($"Presentations given: {report.PresentationsGiven}");
            sb.AppendLine($"1000 Mbps sales: {report.Count1000Mbps} -> {thousand:C}");
            sb.AppendLine($"500 Mbps sales: {report.Count500Mbps} -> {fiveHundred:C}");
            sb.AppendLine($"250 Mbps sales: {report.Count250Mbps} -> {twoFifty:C}");
            sb.AppendLine($"Total sales for the day: {report.GetTotalSales()}");
            sb.AppendLine($"Total commission for the day: {grandTotal:C}");
            sb.AppendLine($"Close rate: {report.GetCloseRate():P1}");
            sb.AppendLine($"Contact rate: {report.GetContactRate():P1}");
            return sb.ToString();
        }

        // Produces a total commission report across every day tracked so far.
        public string GenerateTotalCommissionReport(List<DailySalesReport> reports)
        {
            if (reports.Count == 0)
            {
                return "No daily reports have been added yet.";
            }

            decimal totalThousand = 0m, totalFiveHundred = 0m, totalTwoFifty = 0m, totalOverall = 0m;
            int totalSales = 0;

            foreach (DailySalesReport report in reports)
            {
                var (thousand, fiveHundred, twoFifty, grandTotal) = CalculateDailyCommission(report);
                totalThousand += thousand;
                totalFiveHundred += fiveHundred;
                totalTwoFifty += twoFifty;
                totalOverall += grandTotal;
                totalSales += report.GetTotalSales();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Days tracked: {reports.Count}");
            sb.AppendLine($"Total sales: {totalSales}");
            sb.AppendLine($"Total commission from 1000 Mbps sales: {totalThousand:C}");
            sb.AppendLine($"Total commission from 500 Mbps sales: {totalFiveHundred:C}");
            sb.AppendLine($"Total commission from 250 Mbps sales: {totalTwoFifty:C}");
            sb.AppendLine($"GRAND TOTAL COMMISSION: {totalOverall:C}");
            return sb.ToString();
        }
    }
}

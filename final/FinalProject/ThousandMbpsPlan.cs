using System;

namespace DoorToDoorSalesTracker
{
    // ThousandMbpsPlan pays 100% of the base commission.
    // Demonstrates INHERITANCE (extends InternetPlan) and POLYMORPHISM
    // (overrides the abstract methods with its own behavior).
    public class ThousandMbpsPlan : InternetPlan
    {
        public ThousandMbpsPlan(decimal baseCommission) : base(baseCommission)
        {
        }

        public override string GetPlanName()
        {
            return "1000 Mbps";
        }

        public override decimal GetCommissionRate()
        {
            return 1.00m;
        }
    }
}

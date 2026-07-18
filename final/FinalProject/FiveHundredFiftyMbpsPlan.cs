using System;

namespace DoorToDoorSalesTracker
{
    // FiveHundredMbpsPlan pays 90% of the base commission.
    public class FiveHundredMbpsPlan : InternetPlan
    {
        public FiveHundredMbpsPlan(decimal baseCommission) : base(baseCommission)
        {
        }

        public override string GetPlanName()
        {
            return "500 Mbps";
        }

        public override decimal GetCommissionRate()
        {
            return 0.90m;
        }
    }
}

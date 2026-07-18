using System;

namespace DoorToDoorSalesTracker
{
    // TwoHundredFiftyMbpsPlan pays 80% of the base commission.
    public class TwoHundredFiftyMbpsPlan : InternetPlan
    {
        public TwoHundredFiftyMbpsPlan(decimal baseCommission) : base(baseCommission)
        {
        }

        public override string GetPlanName()
        {
            return "250 Mbps";
        }

        public override decimal GetCommissionRate()
        {
            return 0.80m;
        }
    }
}

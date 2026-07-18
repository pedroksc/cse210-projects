using System;

namespace DoorToDoorSalesTracker
{
    // InternetPlan is an abstract base class representing any internet plan sold.
    // This demonstrates ABSTRACTION: it defines what every plan must be able to do
    // (report its name, its commission rate, and its dollar commission) without
    // saying how each specific plan does it.
    //
    // This class also demonstrates INHERITANCE: ThousandMbpsPlan, FiveHundredMbpsPlan,
    // and TwoHundredFiftyMbpsPlan all inherit from it.
    public abstract class InternetPlan
    {
        // The base commission dollar amount for a full-price (1000 Mbps) sale.
        // Marked protected so derived classes can read it, but outside code cannot.
        protected decimal baseCommission;

        protected InternetPlan(decimal baseCommission)
        {
            this.baseCommission = baseCommission;
        }

        // Every plan must be able to say what it is called.
        public abstract string GetPlanName();

        // Every plan must be able to say what percentage of the base commission it pays.
        // Example: 1.0 = 100%, 0.9 = 90%, 0.8 = 80%.
        public abstract decimal GetCommissionRate();

        // CalculateCommission() is implemented once here (not duplicated in every
        // derived class) because it always does the same math: base commission times
        // whatever rate the derived class provides. This satisfies the requirement
        // that shared logic live in the base class instead of being copy-pasted.
        //
        // It is still virtual so a future plan type could override the math if it
        // ever needed a different calculation.
        public virtual decimal CalculateCommission()
        {
            return baseCommission * GetCommissionRate();
        }

        // Calculates commission for a given quantity of this plan sold in a day.
        public decimal CalculateCommission(int quantitySold)
        {
            return CalculateCommission() * quantitySold;
        }
    }
}

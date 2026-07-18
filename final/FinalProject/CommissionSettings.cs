using System;

namespace DoorToDoorSalesTracker
{
    // CommissionSettings stores the salesperson's base commission per full (1000 Mbps) deal.
    // Demonstrates encapsulation: the field is private and can only be changed through
    // a public method that validates the new value.
    public class CommissionSettings
    {
        private decimal baseCommission;

        public CommissionSettings(decimal baseCommission)
        {
            SetBaseCommission(baseCommission);
        }

        public decimal GetBaseCommission()
        {
            return baseCommission;
        }

        // Public method used to change the base commission safely.
        // Returns false and leaves the value unchanged if the input is invalid.
        public bool SetBaseCommission(decimal newAmount)
        {
            if (newAmount <= 0)
            {
                return false;
            }

            baseCommission = newAmount;
            return true;
        }

        public string ToFileString()
        {
            return baseCommission.ToString("0.00");
        }

        public static CommissionSettings FromFileString(string data)
        {
            decimal amount = decimal.TryParse(data, out decimal result) ? result : 200m;
            return new CommissionSettings(amount);
        }
    }
}

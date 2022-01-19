using System;

namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {
        }
        public override decimal Income()
        {
            decimal startSum = this.Amount;
            decimal middleSum = 0;
            int period = 0;
            while (period < this.Period)
            {
                period++;
                startSum *= 0.05m;
                middleSum += startSum;
                startSum = middleSum + this.Amount;
            }
            decimal round = Math.Round(middleSum, 3);
            return round;
        }
    }
}

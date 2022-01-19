using System;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {

        }
        public bool CanToProlong()
        {
            if(this.Amount > 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override decimal Income()
        {
            decimal startSum = this.Amount;
            decimal middleSum = 0;
            int period = 0;

            while (period < this.Period)
            {
                period++;
                startSum *= 0.01m * period;
                middleSum += startSum;
                startSum = middleSum + this.Amount;
            }
            decimal round = Math.Round(middleSum, 3);
            return round;
        }
    }
}

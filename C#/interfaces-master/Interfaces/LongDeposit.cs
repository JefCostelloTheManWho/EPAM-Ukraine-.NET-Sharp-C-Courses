using System;

namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {

        }
        public override decimal Income()
        {
            decimal startSum = this.Amount;
            decimal middleSum = 0;
            int period = 6;
            if (this.Period > 6)
            {
                while (period < this.Period)
                {
                    period++;
                    startSum *= 0.15m;
                    middleSum += startSum;
                    startSum = middleSum + this.Amount;
                }
            }
            decimal round = Math.Round(middleSum, 3);
            return round;
        }
        public bool CanToProlong()
        {
            if(this.Period <= 36)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

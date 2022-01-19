using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;
        public Client()
        {
            this.deposits = new Deposit[10];
        }
        #region Methods
        public bool AddDeposit(Deposit deposit)
        {
            for (int depos = 0; depos < deposits.Length; depos++)
            {
                //Checking has array free place
                if (deposits[depos] is null)
                {
                    deposits[depos] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal sum = 0;
            for (int deposit = 0; deposit < this.deposits.Length; deposit++)
            {
                if (!(deposits[deposit] is null))
                {
                    sum += this.deposits[deposit].Income();
                }
            }
            return sum;
        }

        public decimal MaxIncome()
        {
            var max = deposits[0];
            for (int depos = 1; depos < deposits.Length; depos++)
            {
                if (!(deposits[depos] is null) && deposits[depos].Income() > max.Income())
                {
                    max = deposits[depos];
                }
            }
            return max.Income();
        }

        public decimal GetIncomeByNumber(int num)
        {
            if (!(deposits[num - 1] is null))
            {
                return deposits[num - 1].Income();
            }
            else
            {
                return 0;
            }
        }
        public void SortDeposits()
        {
            Deposit temp;
            for (int i = 0; i < deposits.Length - 1; i++)
            {
                for (int j = i + 1; j < deposits.Length-1; j++)
                {
                    if (deposits[i].Income() < deposits[j].Income())
                    {
                        temp = deposits[i];
                        deposits[i] = deposits[j];
                        deposits[j] = temp;
                    }
                }
            }
        }
        public int CountPossibleToProlongDeposit()
        {
            int count = 0;
            foreach (var deposit in deposits)
            {
                if((deposit is SpecialDeposit && !(deposit is null)))
                {
                    SpecialDeposit specialDeposit = (SpecialDeposit)deposit;
                    if (specialDeposit.CanToProlong())
                    {
                        count++;
                    }
                }
                else if (deposit is LongDeposit && !(deposit is null))
                {
                    LongDeposit longDeposit = (LongDeposit)deposit;
                    if (longDeposit.CanToProlong())
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        #endregion
        IEnumerator IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return deposits.GetEnumerator() as IEnumerator<Deposit>;
        }
    }
}

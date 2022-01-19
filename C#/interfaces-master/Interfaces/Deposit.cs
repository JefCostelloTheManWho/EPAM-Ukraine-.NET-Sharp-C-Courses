using System;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }
        //According to technical task and sonar better to use protected access modifier
        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            this.Amount = depositAmount;
            this.Period = depositPeriod;
        }
        public abstract decimal Income();
        public int CompareTo(Deposit other)
        {
            if (Amount + Income() < other.Amount + other.Income())
            {
                return -1;
            }
            else if (Amount + Income() > other.Amount + other.Income())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #region Overrides IComparable Methods
        public static bool operator ==(Deposit left, Deposit right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }
        public static bool operator !=(Deposit left, Deposit right)
        {
            return !(left == right);
        }
        public static bool operator <(Deposit left, Deposit right)
        {
            if(left < right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Deposit left, Deposit right)
        {
            if (left > right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            Deposit other = obj as Deposit; //avoid double casting
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.CompareTo(other) == 0;
        }
        public override int GetHashCode()
        {
            return this.Amount.GetHashCode();
        }
        public static bool operator >= (Deposit left, Deposit right)
        {
            if(left >= right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(Deposit left, Deposit right)
        {
            if (left <= right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

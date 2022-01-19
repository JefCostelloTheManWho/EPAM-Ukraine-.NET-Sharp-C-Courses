namespace InheritanceTask
{
    public class Employee
    {
        #region Fields
        private decimal bonus;
        private decimal salary;
        private readonly string name;
        #endregion
        #region Proporties
        public string Name => this.name;
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (this.salary > 0)
                {
                    this.salary = value;
                }
            }
        }
        #endregion
        #region Constructors
        public Employee(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }
        #endregion
        #region Methods
        public virtual void SetBonus(decimal bonus)
        {
            this.bonus += bonus;
        }
        public decimal ToPay()
        {
            decimal sum;
            sum = bonus + salary;
            return sum;
        }
        #endregion
    }
}

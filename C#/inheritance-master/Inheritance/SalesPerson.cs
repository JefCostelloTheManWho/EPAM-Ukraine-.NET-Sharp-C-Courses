namespace InheritanceTask
{
    public class SalesPerson : Employee
    {
        #region Fields
        private readonly int percent;
        #endregion
        #region Constructors
        public SalesPerson(string name, decimal salary, int percent) : base(name, salary)
        {
            this.percent = percent;
        }
        #endregion
        #region Methods
        public override void SetBonus(decimal bonus)
        {
            if (percent < 100)
            {
                base.SetBonus(bonus);
            }
            else if (percent >= 100 && percent < 200)
            {
                base.SetBonus(bonus * 2);
            }
            else if (percent >= 200)
            {
                base.SetBonus(bonus * 3);
            }
        }
        #endregion
    }
}

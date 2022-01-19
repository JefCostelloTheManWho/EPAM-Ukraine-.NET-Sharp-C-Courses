namespace InheritanceTask
{
    public class Manager : Employee
    {
        #region Fields
        private readonly int quantity;
        #endregion
        #region Constructors
        public Manager(string name, decimal salary, int clientAmount) : base(name, salary)
        {
            this.quantity = clientAmount;
        }
        #endregion
        #region Methods
        public override void SetBonus(decimal bonus)
        {
            base.SetBonus(bonus);
            if (this.quantity > 100 && this.quantity < 200)
            {
                bonus = 500;
                base.SetBonus(bonus);
            }
            else if (this.quantity >= 200)
            {
                bonus = 1000;
                base.SetBonus(bonus);
            }
        }
        #endregion
    }
}


using System;
namespace InheritanceTask
{
    public class Company
    {
        #region Fields
        private readonly Employee[] employees;
        #endregion
        #region Constructors
        public Company(Employee[] employees)
        {
            this.employees = employees;
        }
        #endregion
        #region Methods
        public void GiveEverybodyBonus(decimal companyBonus)
        {
            for (int emp = 0; emp < this.employees.Length; emp++)
            {
                if (employees[emp] != null)
                {
                    employees[emp].SetBonus(companyBonus);
                }
           
            }
        }
        public decimal TotalToPay()
        {
            decimal totalToPay = 0;
            foreach (var employee in this.employees)
            {
                totalToPay += employee.ToPay();
            }
            return totalToPay;
        }
        public string NameMaxSalary()
        {
            var max = employees[0];
            for (int i = 1; i < employees.Length; i++)
            {
                if (employees[i].ToPay() > max.ToPay())
                {
                    max = employees[i];
                }
            }
            return max.Name;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees
{
    class Doctor:Employee
    {
       

        /// <summary>
        /// преміальні години
        /// </summary>
        public virtual double PremiumHours { get { return 0; } set { _premiumHours = value; } }
        protected double _premiumHours;
        /// <summary>
        /// кількість вилікуванних
        /// </summary>
        public int CountOfTreated { get; set; }
        /// <summary>
        /// бонус за кожного вилікуванного
        /// </summary>
        public double BonusPaid { get; set; }
        /// <summary>
        ///  робочих годин на місяць
        /// </summary>
        public double HoursOfMonth { get; set; }

        public override double CalculateBonusPaid()
        {
            return BonusPaid * CountOfTreated;
        }

        public override double PaidOfMonth()
        {
            return (this.HoursOfMonth*this.PaidOfHour)+this.CalculateBonusPaid()+this.CalculatePremiumPaid();
        }

        public override double CalculatePremiumPaid()
        {
            return PremiumHours * this.PaidOfHour;
        }
    }
}

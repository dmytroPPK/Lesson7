using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees
{
    class Worker : Employee
    {
        /// <summary>
        /// к-сть годин зверх норми
        /// </summary>
        public int OverOfHours { get; set; }
        /// <summary>
        /// преміальні години
        /// </summary>
        public virtual double PremiumHours { get { return _premiumHours * 4; } set { _premiumHours = value; } }
        protected double _premiumHours;
        /// <summary>
        ///  робочих годин на місяць
        /// </summary>
        public double HoursOfMonth { get; set; }

        public override double CalculateBonusPaid()
        {

            return this.OverOfHours * this.PaidOfHour;
        }

        public override double PaidOfMonth()
        {
            return (this.HoursOfMonth * this.PaidOfHour) + this.CalculateBonusPaid() + this.CalculatePremiumPaid();
        }

        public override double CalculatePremiumPaid()
        {
            return this.PremiumHours * this.PaidOfHour;
        }
    }
}

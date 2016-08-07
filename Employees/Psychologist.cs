using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees
{
    class Psychologist:Employee
    {
        /// <summary>
        /// кількість пацієнтів зверх норми
        /// </summary>
        public int CountOverPatient { get; set; }
        /// <summary>
        /// загальний коефіцієнт за всіх не нормованих пацієнтів
        /// </summary>
        public double FactorOfBonus { get { return (CountOverPatient>0)?CountOverPatient*1.2:0; } }
        /// <summary>
        /// преміальні години
        /// </summary>
        public virtual double PremiumHours { get { return _premiumHours * 2; } set { _premiumHours = value; } }
        protected double _premiumHours;
        /// <summary>
        ///  робочих годин на місяць
        /// </summary>
        public double HoursOfMonth { get; set; }

        public override double CalculateBonusPaid()
        {
            return this.FactorOfBonus * this.CountOverPatient * this.PaidOfHour;
        }

        public override double PaidOfMonth()
        {
            return (this.PaidOfHour * this.HoursOfMonth) + this.CalculateBonusPaid() + this.CalculatePremiumPaid();
        }

        public override double CalculatePremiumPaid()
        {
            return this.PremiumHours * this.PaidOfHour;
        }
    }
}

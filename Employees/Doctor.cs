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
        public virtual double PremiumHours { get { return (_isTrainee)?_premiumHours*1.5:0; } set { _premiumHours = value; } }
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

        public Doctor(bool trainee = false) : base(trainee) { }
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
        public override string ToString()
        {
            return string.Format(Helper.infoDoctor,
                Name, 
                Age, 
                EperienceYears,
                CalculateBonusPaid(),
                CalculatePremiumPaid(),
                PaidOfMonth(),
                PremiumHours, 
                CountOfTreated,
                HoursOfMonth,
                PaidOfHour, 
                (this.IsTrainee)?"Так":"Ні",
                BonusPaid);
        }
    }
}

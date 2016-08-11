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
        public virtual double PremiumHours { get { return (_isTrainee) ? _premiumHours * 1.5 :  _premiumHours * 4; } set { _premiumHours = value; } }
        protected double _premiumHours;
        /// <summary>
        ///  робочих годин на місяць
        /// </summary>
        public double HoursOfMonth { get; set; }

        public Worker(bool trainee = false) : base(trainee) { }

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
        public override string ToString()
        {
            
            return string.Format(Helper.infoWorker,  
                this.Name, 
                this.Age, 
                this.EperienceYears,
                this.CalculateBonusPaid(),
                this.CalculatePremiumPaid(),
                this.PaidOfMonth(),
                this.PremiumHours,
                this.OverOfHours,
                this.HoursOfMonth,
                this.PaidOfHour, 
                (this.IsTrainee)?"Так":"Ні");
        }
    }
}

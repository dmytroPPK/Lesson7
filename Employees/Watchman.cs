using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees
{
    class Watchman : Employee
    {
        /// <summary>
        /// кількість денних годин роботи
        /// </summary>
        public int HoursOfDay { get; set; }
        protected int _hoursOfNight;
        /// <summary>
        /// кількість нічних годин роботи
        /// </summary>
        public int HoursOfNight { get { return _hoursOfNight*2 ; } set { _hoursOfNight = value; } }
        /// <summary>
        /// преміальні години  за день
        /// </summary>
        public virtual double PremiumHoursDay { get { return (_isTrainee) ? _premiumHoursDay * 1.5 :  _premiumHoursDay * 2; } set { _premiumHoursDay = value; } }
        protected double _premiumHoursDay;
        /// <summary>
        /// преміальні години  за ніч
        /// </summary>
        public virtual double PremiumHoursNight { get { return (_isTrainee) ? _premiumHoursNight * 1.5 :  _premiumHoursNight * 3; } set { _premiumHoursNight = value; } }
        protected double _premiumHoursNight;

        public Watchman(bool trainee = false) : base(trainee) { }

        public override double CalculateBonusPaid()
        {
            return 0;
        }

        public override double PaidOfMonth()
        {
            return (this.HoursOfDay + this.HoursOfNight) * this.PaidOfHour + this.CalculateBonusPaid() + this.CalculatePremiumPaid();
        }

        public override double CalculatePremiumPaid()
        {
            return (this.PremiumHoursDay + this.PremiumHoursNight) * this.PaidOfHour;
        }
        public override string ToString()
        {
            return string.Format(Helper.infoWatchMan,
                Name,
                Age,
                EperienceYears,
                CalculateBonusPaid(),
                CalculatePremiumPaid(),
                PaidOfMonth(),
                HoursOfDay,
                HoursOfNight,
                PremiumHoursDay,
                PremiumHoursNight,PaidOfHour,
                (this.IsTrainee)?"Так":"Ні");
        }
    }
}

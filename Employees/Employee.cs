using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees
{
    abstract class Employee
    {
        public int UId { get; set; }
        /// <summary>
        /// плата за годину
        /// </summary>
        public double PaidOfHour { get; set; }
        /// <summary>
        /// стаж
        /// </summary>
        public int EperienceYears { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public abstract double CalculateBonusPaid();
        public abstract double PaidOfMonth();
        public abstract double CalculatePremiumPaid();

        protected bool _isTrainee;
        public bool IsTrainee { get { return _isTrainee; } }

        public Employee(bool isTrainee = false)
        {
            this._isTrainee = isTrainee;
        }
    }
}

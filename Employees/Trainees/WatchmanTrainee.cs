using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees.Trainees
{
    sealed class WatchmanTrainee : Watchman, ITrainee
    {
        public override double PremiumHoursDay { get { return _premiumHoursDay * 1.5; } set { _premiumHoursDay = value; } }
        public override double PremiumHoursNight { get { return _premiumHoursNight * 1.5; } set { _premiumHoursNight = value; } }
    }
}

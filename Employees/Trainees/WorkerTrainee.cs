using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Employees.Trainees
{
    sealed class WorkerTrainee : Worker, ITrainee
    {
        public override double PremiumHours { get { return _premiumHours * 1.5; } set { _premiumHours = value; } }
        
    }
}

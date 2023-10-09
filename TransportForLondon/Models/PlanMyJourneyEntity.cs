using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLFramework.Models
{
    public class PlanMyJourneyEntity
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

        public string Option { get; set; }

        public string DepartureTime { get; set; }
    }
}
